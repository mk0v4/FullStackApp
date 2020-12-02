using System.Threading.Tasks;
using PagedList;
using Tasker.Common.Find.Interface;
using Tasker.Model.Common;
using Tasker.Model.Common.FilterModels;

namespace Tasker.Service.Common
{
    public interface IProjectTaskService
    {
        Task<int> AddAsync(IProjectTask project);
        Task<IProjectTask> Get(long id);
        Task<int> DeleteAsync(long id);
        Task<int> UpdateAsync(IProjectTask project);
        Task<IPagedList<IProjectTask>> Find(IProjectTaskFilterParams projectTaskFilterParams, IFindParams filteringElements);
    }
}