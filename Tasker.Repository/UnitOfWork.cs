using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Tasker.DAL.DataAccess.Interface;
using Tasker.Repository.Common;

namespace Tasker.Repository
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private protected readonly IApplicationDbContext _dbContext;
        public UnitOfWork(IApplicationDbContext context)
        {
            if (_dbContext == null)
            {
                throw new ArgumentNullException("DbContext");
            }
            _dbContext = context;
        }
        //Create
        public virtual Task<int> AddAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = _dbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                _dbContext.Set<T>().Add(entity);
            }
            return Task.FromResult(1);
        }
        public virtual Task<int> DeleteAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = _dbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                _dbContext.Set<T>().Attach(entity);
                _dbContext.Set<T>().Remove(entity);
            }
            return Task.FromResult(1);
        }

        public virtual Task<int> DeleteAsync<T>(long id) where T : class
        {
            T entity = _dbContext.Set<T>().Find(id);
            if (entity == null)
            {
                return Task.FromResult(0);
            }
            return DeleteAsync<T>(entity);
        }

        //Update
        public virtual Task<int> UpdateAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = _dbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                _dbContext.Set<T>().Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
            return Task.FromResult(1);
        }

        public async Task<T> Get<T>(long id) where T : class
        {
            T entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<IQueryable<T>> GetAll<T>() where T : class
        {
            IEnumerable<T> entities = await _dbContext.Set<T>().ToListAsync();
            return entities.AsQueryable();
        }
        public async Task<int> CommitAsync()
        {
            int result = 0;
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                result = await _dbContext.SaveChangesAsync();
                scope.Complete();
            }
            return result;
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}