using System.Threading.Tasks;
using PagedList;
using Tasker.Service.DataAccess.Interface;
using Tasker.Service.FilterModels.Interface;
using Tasker.Service.Models;

namespace Tasker.Service.Service.Interface
{
    public interface ITimeEntryService
    {
        Task<int> Create(TimeEntry project);
        Task<TimeEntry> Get(long id);
        Task<int> Delete(long id);
        Task<TimeEntry> Update(TimeEntry project);
        Task<IPagedList<TimeEntry>> Find(ITimeEntryFilterParams timeEntryFilterParams, IFindParams filteringElements);
    }
}
