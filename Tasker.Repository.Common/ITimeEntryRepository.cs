using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasker.Common.Find.Interface;
using Tasker.Model.Common;

namespace Tasker.Repository.Common
{
    public interface ITimeEntryRepository
    {
        Task<int> AddAsync(ITimeEntry entity);
        Task<int> DeleteAsync(long id);
        Task<int> DeleteAsync(ITimeEntry entity);
        Task<int> UpdateAsync(ITimeEntry entity);
        Task<ITimeEntry> GetAsync(long id);
        IList<ITimeEntry> Find(IFindParams findParams);
    }
}
