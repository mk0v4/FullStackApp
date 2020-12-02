using System.Threading.Tasks;
using PagedList;
using Tasker.Common.Find.Interface;
using Tasker.Model.Common;
using Tasker.Model.Common.FilterModels;

namespace Tasker.Service.Common
{
    public interface IProjectService
    {
        Task<int> AddAsync(IProject project);
        Task<IProject> Get(long id);
        Task<int> DeleteAsync(long id);
        Task<int> UpdateAsync(IProject project);
        Task<IPagedList<IProject>> Find(IProjectFilterParams projectFilterParams, IFindParams filteringElements);
    }
}