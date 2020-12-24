using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasker.Common.Find.Interface;
using Tasker.Model.Common;

namespace Tasker.Repository.Common
{
    public interface IProjectTaskRepository
    {
        Task<int> AddAsync(IProjectTask entity);
        Task<int> DeleteAsync(long id);
        Task<int> DeleteAsync(IProjectTask entity);
        Task<int> UpdateAsync(IProjectTask entity);
        Task<IProjectTask> GetAsync(long id);
        IList<IProjectTask> Find(IFindParams findParams);
    }
}
