using System.Threading.Tasks;
using Tasker.Service.Common;

namespace Tasker.Service.DataAccess.Interface
{
    public interface IGenericDataService<T> where T : Entity
    {
        Task<int> Create<E>(T entity) where E : Entity;
        Task<int> Delete(long id);
        Task<T> Get(long id);
        Task<T> Update<E>(T entity) where E : Entity;
    }
}
