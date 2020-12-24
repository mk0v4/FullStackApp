using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tasker.Common.Find.Interface;
using Tasker.Model.Common;
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
            ITimeEntry timeEntry = await _timeEntryRepository.GetAsync(id);
            if (timeEntry == null)
                throw new Exception("Entity not found!");
            return timeEntry;

        }
        public async Task<IList<ITimeEntry>> Find(IFindParams findParams)
        {
            return _timeEntryRepository.Find(findParams);
        }
        public void ValidateModel(ITimeEntry timeEntry, Action<string, string> modelError)
        {
            if (timeEntry == null)
            {
                modelError("Model", "Model is null");
            }
        }
    }
}
