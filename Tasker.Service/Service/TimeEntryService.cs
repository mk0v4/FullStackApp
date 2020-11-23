using System.Linq;
using System.Threading.Tasks;
using PagedList;
using Tasker.Service.DataAccess;
using Tasker.Service.DataAccess.Interface;
using Tasker.Service.FilterModels;
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
        public async Task<IPagedList<TimeEntry>> Find(FindParams findElements)
        {
            IQueryable<TimeEntry> source = Enumerable.Empty<TimeEntry>().AsQueryable();
            if (findElements.Id != null)
            {
                source = await base.GetAll();
                source = source.Where(te => te.ProjectTaskId == findElements.Id);
            }

            Filter<TimeEntry> filter = new Filter<TimeEntry>(new TimeEntryFilterParams());
            Sort<TimeEntry> sort = new Sort<TimeEntry>();
            sort.SortData(findElements, filter.FilterData(findElements, source));
            Paging<TimeEntry> paging = new Paging<TimeEntry>();

            return paging.PaginateData(findElements, sort.SortData(findElements, filter.FilterData(findElements, source)));
        }
    }
}
