using System.Linq;
using System.Threading.Tasks;
using PagedList;
using Tasker.Service.DataAccess;
using Tasker.Service.DataAccess.Interface;
using Tasker.Service.FilterModels.Interface;
using Tasker.Service.Models;
using Tasker.Service.Service.Interface;

namespace Tasker.Service.Service
{
    public class TimeEntryService : GenericDataService<TimeEntry>, ITimeEntryService
    {
        public TimeEntryService(IApplicationDbContext context) : base(context)
        {
        }
        public async Task<int> Create(TimeEntry projectTask)
        {
            return await base.Create<TimeEntry>(projectTask);
        }
        public new async Task<int> Delete(long id)
        {
            return await base.Delete(id);
        }
        public async Task<TimeEntry> Update(TimeEntry projectTask)
        {
            return await base.Update<TimeEntry>(projectTask);
        }
        public new async Task<TimeEntry> Get(long id)
        {
            return await base.Get(id);

        }
        public async Task<IPagedList<TimeEntry>> Find(ITimeEntryFilterParams timeEntryFilterParams, IFindParams findParams)
        {
            IQueryable<TimeEntry> source = Enumerable.Empty<TimeEntry>().AsQueryable();
            if (findParams.Id != null)
            {
                source = await base.GetAll();
                source = source.Where(te => te.ProjectTaskId == findParams.Id);
            }
            source = new Filter<TimeEntry>(timeEntryFilterParams).FilterData(source);
            source = new Sort<TimeEntry>().SortData(findParams, source);
            return new Paging<TimeEntry>().PaginateData(findParams, source);
        }
    }
}
