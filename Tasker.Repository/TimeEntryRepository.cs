using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Tasker.Common.Find;
using Tasker.Common.Find.Interface;
using Tasker.DAL.Entities;
using Tasker.Model.Common;
using Tasker.Model.FilterModels;
using Tasker.Repository.Common;

namespace Tasker.Repository
{
    public class TimeEntryRepository : Repository, ITimeEntryRepository
    {
        private protected readonly IMapper _mapper;
        public TimeEntryRepository(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            this._mapper = mapper;
        }
        public async Task<int> AddAsync(ITimeEntry entity)
        {
            return await base.AddAsync<TimeEntryEntity>(_mapper.Map<TimeEntryEntity>(entity));
        }
        public async Task<int> DeleteAsync(long id)
        {
            return await base.DeleteAsync<TimeEntryEntity>(id);
        }
        public async Task<int> DeleteAsync(ITimeEntry entity)
        {
            return await base.DeleteAsync<TimeEntryEntity>(_mapper.Map<TimeEntryEntity>(entity));
        }
        public async Task<int> UpdateAsync(ITimeEntry entity)
        {
            return await base.UpdateAsync<TimeEntryEntity>(_mapper.Map<TimeEntryEntity>(entity));
        }
        public async Task<ITimeEntry> GetAsync(long id)
        {
            return _mapper.Map<ITimeEntry>(await base.GetAsync<TimeEntryEntity>(id));
        }
        public IList<ITimeEntry> Find(IFindParams findParams)
        {
            IQueryable<TimeEntryEntity> timeEntriesQueryable = base.Find<TimeEntryEntity>();
            timeEntriesQueryable = timeEntriesQueryable.Where(pt => pt.ProjectTaskId == findParams.Id);
            timeEntriesQueryable = new Filter<TimeEntryEntity>(new TimeEntryFilterParams()).FilterData(findParams, timeEntriesQueryable);
            timeEntriesQueryable = new Sort<TimeEntryEntity>().SortData(findParams, timeEntriesQueryable);
            timeEntriesQueryable = new Paging<TimeEntryEntity>().PaginateData(findParams, timeEntriesQueryable);
            return _mapper.Map<IList<ITimeEntry>>(timeEntriesQueryable.ToList());
        }
    }
}
