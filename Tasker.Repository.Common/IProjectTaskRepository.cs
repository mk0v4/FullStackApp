using System.Linq;
using System.Threading.Tasks;
using Tasker.Model.Common;

namespace Tasker.Repository.Common
{
    public interface IProjectTaskRepository
    {
        Task<int> AddAsync(IProjectTask entity);
        Task<int> DeleteAsync(long id);
        Task<int> DeleteAsync(IProjectTask entity);
        Task<int> UpdateAsync(IProjectTask entity);
        Task<IProjectTask> Get(long id);
        Task<IQueryable<IProjectTask>> GetAll();
    }
}
