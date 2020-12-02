using System;
using System.Linq;
using System.Threading.Tasks;

namespace Tasker.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> AddAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(long id) where T : class;
        Task<int> DeleteAsync<T>(T entity) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;
        Task<int> CommitAsync();
        Task<T> Get<T>(long id) where T : class;
        Task<IQueryable<T>> GetAll<T>() where T : class;
    }
}
