﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Tasker.Service.Common;
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
        public async Task<IQueryable<T>> GetAll()
        {
            IEnumerable<T> enteties =  await _dbContext.Set<T>().ToListAsync();
            return enteties.AsQueryable();
        }
    }
}