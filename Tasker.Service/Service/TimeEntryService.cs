using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Tasker.Service.DataAccess;
using Tasker.Service.DataAccess.Interface;
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
        [Obsolete("Method is deprecated.", true)]
        public async Task<IPagedList<TimeEntry>> Filter(long? id, string property, object value, int? pageNumber, int pageSize, string sortBy, string sortDirection)
        {
            IQueryable<TimeEntry> source = Enumerable.Empty<TimeEntry>().AsQueryable();
            if (id != null)
            {
                source = await base.GetAll();
                source = source.Where(te => te.ProjectTaskId == id);
            }
            return base.Filter(source, property, value, pageNumber, pageSize, sortBy, sortDirection);
        }

        public async Task<IPagedList<TimeEntry>> Filter(FilteringElements filteringElements)
        {
            IQueryable<TimeEntry> source = Enumerable.Empty<TimeEntry>().AsQueryable();
            if (filteringElements.Id != null)
            {
                source = await base.GetAll();
                source = source.Where(te => te.ProjectTaskId == filteringElements.Id);
            }
            return base.Filter(source, filteringElements);
        }
    }
}
