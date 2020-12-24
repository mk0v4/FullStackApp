using System;
using System.Linq;
using System.Linq.Expressions;
using Tasker.Common.Find.Interface;

namespace Tasker.Common.Find
{
    public class Sort<T> : ISort<T>
    {
        public IQueryable<T> SortData(IFindParams filterElements, IQueryable<T> data)
        {
            string sortBy = filterElements.SortBy;
            string sortDirection = filterElements.SortDirection;
            if (String.IsNullOrEmpty(sortBy) || String.IsNullOrEmpty(sortDirection))
            {
                sortBy = "Id";
                sortDirection = "asc";
            }
            string sortMethod = "";
            switch (sortDirection.ToLower())
            {
                case "asc":
                    sortMethod = "OrderBy";
                    break;
                case "desc":
                    sortMethod = "OrderByDescending";
                    break;
                default:
                    sortMethod = "OrderByDescending";
                    break;
            }
            var param = Expression.Parameter(typeof(T), "item");
            var select = Expression.Lambda(Expression.Property(param, sortBy), param);
            Expression query = Expression.Call(typeof(Queryable), sortMethod, new Type[] {
                data.ElementType, typeof(T).GetProperty(sortBy).PropertyType }, data.Expression, select);

            return data.Provider.CreateQuery<T>(query);
        }
    }
}
