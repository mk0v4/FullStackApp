using System.Threading.Tasks;
using PagedList;
using Tasker.Common.Find.Interface;
using Tasker.Model.Common;
using Tasker.Model.Common.FilterModels;

namespace Tasker.Service.Common
{
    public interface ITimeEntryService
    {
        Task<int> AddAsync(ITimeEntry project);
        Task<ITimeEntry> Get(long id);
        Task<int> DeleteAsync(long id);
        Task<int> UpdateAsync(ITimeEntry project);
        Task<IPagedList<ITimeEntry>> Find(ITimeEntryFilterParams timeEntryFilterParams, IFindParams filteringElements);
    }
}
