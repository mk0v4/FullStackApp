using System.Linq;
using System.Threading.Tasks;
using PagedList;
using Tasker.Common.Find;
using Tasker.Common.Find.Interface;
using Tasker.Model;
using Tasker.Model.Common;
using Tasker.Model.Common.FilterModels;
using Tasker.Repository.Common;
using Tasker.Service.Common;

namespace Tasker.Service
{
    public class TimeEntryService : ITimeEntryService
    {
        private protected readonly ITimeEntryRepository _timeEntryRepository;
        public TimeEntryService(ITimeEntryRepository timeEntryRepository)
        {
            _timeEntryRepository = timeEntryRepository;
        }
        public async Task<int> AddAsync(ITimeEntry projectTask)
        {
            return await _timeEntryRepository.AddAsync(projectTask);
        }
        public async Task<int> DeleteAsync(long id)
        {
            return await _timeEntryRepository.DeleteAsync(id);
        }
        public async Task<int> UpdateAsync(ITimeEntry projectTask)
        {
            return await _timeEntryRepository.UpdateAsync(projectTask);
        }
        public async Task<ITimeEntry> Get(long id)
        {
            return await _timeEntryRepository.Get(id);

        }
        public async Task<IPagedList<ITimeEntry>> Find(ITimeEntryFilterParams timeEntryFilterParams, IFindParams findParams)
        {
            IQueryable<TimeEntry> source = Enumerable.Empty<TimeEntry>().AsQueryable();
            if (findParams.Id != null)
            {
                source = (IQueryable<TimeEntry>) await _timeEntryRepository.GetAll();
                source = source.Where(te => te.ProjectTaskId == findParams.Id);
            }
            source = new Filter<TimeEntry>(timeEntryFilterParams).FilterData(source);
            source = new Sort<TimeEntry>().SortData(findParams, source);
            return new Paging<TimeEntry>().PaginateData(findParams, source);
        }
    }
}
