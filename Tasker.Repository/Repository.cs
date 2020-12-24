using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tasker.DAL.Entities.Common;
using Tasker.Repository.Common;

namespace Tasker.Repository
{
    public abstract class Repository : IRepository
    {
        private protected readonly IUnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public virtual async Task<int> AddAsync<T>(T entity) where T : Entity
        {
            await _unitOfWork.AddAsync<T>(entity);
            return await _unitOfWork.CommitAsync();
        }
        public virtual async Task<int> DeleteAsync<T>(long id) where T : Entity
        {
            await _unitOfWork.DeleteAsync<T>(id);
            return await _unitOfWork.CommitAsync();
        }
        public virtual async Task<int> DeleteAsync<T>(T entity) where T : Entity
        {
            await _unitOfWork.DeleteAsync<T>(entity);
            return await _unitOfWork.CommitAsync();
        }
        public virtual async Task<int> UpdateAsync<T>(T entity) where T : Entity
        {
            await _unitOfWork.UpdateAsync<T>(entity);
            return await _unitOfWork.CommitAsync();
        }
        public virtual async Task<T> GetAsync<T>(long id) where T : Entity
        {
            return await _unitOfWork.GetAsync<T>(id);
        }
        public virtual IQueryable<T> Find<T>() where T : Entity
        { 
            return _unitOfWork.Set<T>();
        }
    }
}
