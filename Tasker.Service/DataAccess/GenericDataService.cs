using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Tasker.Service.Common;
using Tasker.Service.DataAccess;
using Tasker.Service.DataAccess.Interface;

namespace Tasker.Service.DataAccess
{
    public abstract class GenericDataService<T> : IGenericDataService<T> where T : Entity
    {
        private readonly IApplicationDbContext _dbContext;
        public GenericDataService(IApplicationDbContext context)
        {

            this._dbContext = context;
        }

        public async Task<int> Create<E>(T entity) where E : Entity
        {
            _dbContext.Set<T>().Add(entity);
            return await _dbContext.SaveChangesAsync();
        }
        
        public async Task<int> Delete(long id)
        {
            T entity = await _dbContext.Set<T>().FindAsync(id);
            _dbContext.Set<T>().Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<T> Get(long id)
        {
            T entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<T> Update<E>(T entity) where E : Entity
        {
            _dbContext.Set<T>().AddOrUpdate(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public IPagedList<T> Filter(IQueryable<T> source, string property, object value, 
            int? pageNumber, int pageSize, string sortBy, string sortDirection)
        {
            if (String.IsNullOrEmpty(property))
            {
                return Sort(source, sortBy, sortDirection).ToPagedList(pageNumber ?? 1, pageSize);
            }
            if (typeof(T).GetProperty(property).PropertyType == typeof(string))
            {
                source = source.Where(t => 
                t.GetType().GetProperty(property).GetValue(t, null) != null ?
                t.GetType().GetProperty(property).GetValue(t, null).ToString().ToLower().Contains(value.ToString().ToLower()) : "".Contains(value.ToString()));
            } else if (typeof(T).GetProperty(property).PropertyType.IsEnum)
            {
                Type enumType = typeof(T).GetProperty(property).PropertyType;
                source = source.Where(t => t.GetType().GetProperty(property).GetValue(t, null).ToString().Equals(Enum.GetName(enumType, value)));
            } else if (typeof(T).GetProperty(property).PropertyType == typeof(Nullable<DateTime>))
            {
                if (value != null)
                    source = source.Where(t => DateTime.Compare(Convert.ToDateTime(t.GetType().GetProperty(property).GetValue(t, null)), Convert.ToDateTime(value)) >= 0);
                else
                {
                    source = source.Where(t => t.GetType().GetProperty(property).GetValue(t, null) == null);
                }
            } else if (typeof(T).GetProperty(property).PropertyType == typeof(bool)) {
                source = source.Where(t => t.GetType().GetProperty(property).GetValue(t, null).Equals(value));
            } else if (typeof(T).GetProperty(property).PropertyType == typeof(Nullable<TimeSpan>))
            {
                if (value != null)
                    source = source.Where(t => t.GetType().GetProperty(property).GetValue(t, null) != null &&
                    TimeSpan.Compare((TimeSpan) t.GetType().GetProperty(property).GetValue(t, null), (TimeSpan) value) >= 0);
                else
                {
                    source = source.Where(t => t.GetType().GetProperty(property).GetValue(t, null) == null);
                }
            }
            return Sort(source, sortBy, sortDirection).ToPagedList(pageNumber ?? 1, pageSize);
        }

        private IQueryable<T> Sort(IQueryable<T> source, string sortBy, string sortDirection)
        {
            
            if (String.IsNullOrEmpty(sortBy) || String.IsNullOrEmpty(sortDirection))
            {
                sortBy = "Id";
                sortDirection = "asc";
            }
            var param = Expression.Parameter(typeof(T), "item");

            var sortExpression = Expression.Lambda<Func<T, object>>
                (Expression.Convert(Expression.Property(param, sortBy), typeof(object)), param);
            switch (sortDirection.ToLower())
            {
                case "asc":
                    return source.OrderBy<T, object>(sortExpression);
                default:
                    return source.OrderByDescending<T, object>(sortExpression);
            }
        }
        public async Task<IQueryable<T>> GetAll()
        {
            IEnumerable<T> enteties =  await _dbContext.Set<T>().ToListAsync();
            return enteties.AsQueryable();
        }
    }
}