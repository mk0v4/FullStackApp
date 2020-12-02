using System.Linq;
using System.Threading.Tasks;
using Tasker.Model.Common;

namespace Tasker.Repository.Common
{
    public interface IProjectRepository
    {
        Task<int> AddAsync(IProject entity);
        Task<int> DeleteAsync(long id);
        Task<int> DeleteAsync(IProject entity);
        Task<int> UpdateAsync(IProject entity);
        Task<IProject> Get(long id);
        Task<IQueryable<IProject>> GetAll();
    }
}
