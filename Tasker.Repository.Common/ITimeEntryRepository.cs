using System.Linq;
using System.Threading.Tasks;
using Tasker.Model.Common;

namespace Tasker.Repository.Common
{
    public interface ITimeEntryRepository
    {
        Task<int> AddAsync(ITimeEntry entity);
        Task<int> DeleteAsync(long id);
        Task<int> DeleteAsync(ITimeEntry entity);
        Task<int> UpdateAsync(ITimeEntry entity);
        Task<ITimeEntry> Get(long id);
        Task<IQueryable<ITimeEntry>> GetAll();
    }
}
