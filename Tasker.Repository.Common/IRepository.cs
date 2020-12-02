using System.Linq;
using System.Threading.Tasks;
using Tasker.DAL.Entities.Common;

namespace Tasker.Repository.Common
{
    public interface IRepository
    {
        Task<int> AddAsync<T>(T entity) where T : Entity;
        Task<int> DeleteAsync<T>(long id) where T : Entity;
        Task<int> DeleteAsync<T>(T entity) where T : Entity;
        Task<int> UpdateAsync<T>(T entity) where T : Entity;
        Task<T> Get<T>(long id) where T : Entity;
        Task<IQueryable<T>> GetAll<T>() where T : Entity;
    }
}