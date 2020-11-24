using System.Threading.Tasks;
using PagedList;
using Tasker.Service.DataAccess.Interface;
using Tasker.Service.FilterModels.Interface;
using Tasker.Service.Models;

namespace Tasker.Service.Service.Interface
{
    public interface IProjectService
    {
        Task<int> Create(Project project);
        Task<Project> Get(long id);
        Task<int> Delete(long id);
        Task<Project> Update(Project project);
        Task<IPagedList<Project>> Find(IProjectFilterParams projectFilterParams, IFindParams filteringElements);
    }
}