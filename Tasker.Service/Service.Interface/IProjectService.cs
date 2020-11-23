using System.Threading.Tasks;
using PagedList;
using Tasker.Service.DataAccess;
using Tasker.Service.Models;

namespace Tasker.Service.Service.Interface
{
    public interface IProjectService
    {
        Task<int> Create(Project project);
        Task<Project> Get(long id);
        Task<int> Delete(long id);
        Task<Project> Update(Project project);
        Task<IPagedList<Project>> Find(FindParams filteringElements);
    }
}