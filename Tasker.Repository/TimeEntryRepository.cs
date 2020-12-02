using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Tasker.DAL.Entities;
using Tasker.Model.Common;
using Tasker.Repository.Common;

namespace Tasker.Repository
{
    public class TimeEntryRepository : Repository, ITimeEntryRepository
    {
        public TimeEntryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<int> AddAsync(ITimeEntry entity)
        {
            return await base.AddAsync<TimeEntryEntity>(Mapper.Map<TimeEntryEntity>(entity));
        }
        public async Task<int> DeleteAsync(long id)
        {
            return await base.DeleteAsync<TimeEntryEntity>(id);
        }
        public async Task<int> DeleteAsync(ITimeEntry entity)
        {
            return await base.DeleteAsync<TimeEntryEntity>(Mapper.Map<TimeEntryEntity>(entity));
        }
        public async Task<int> UpdateAsync(ITimeEntry entity)
        {
            return await base.UpdateAsync<TimeEntryEntity>(Mapper.Map<TimeEntryEntity>(entity));
        }
        public async Task<ITimeEntry> Get(long id)
        {
            return Mapper.Map<ITimeEntry>(await base.Get<TimeEntryEntity>(id));
        }
        public async Task<IQueryable<ITimeEntry>> GetAll()
        {
            return Mapper.Map<IQueryable<ITimeEntry>>(await base.GetAll<TimeEntryEntity>());
        }
    }
}
