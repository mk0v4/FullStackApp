using System.Threading.Tasks;
using PagedList;
using Tasker.Service.DataAccess;
using Tasker.Service.Models;

namespace Tasker.Service.Service.Interface
{
    public interface IProjectTaskService
    {
        Task<int> Create(ProjectTask project);
        Task<ProjectTask> Get(long id);
        Task<int> Delete(long id);
        Task<ProjectTask> Update(ProjectTask project);
        Task<IPagedList<ProjectTask>> Find(FindParams filteringElements);
    }
}