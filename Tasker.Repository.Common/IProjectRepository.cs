using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasker.Common.Find.Interface;
using Tasker.Model.Common;

namespace Tasker.Repository.Common
{
    public interface IProjectRepository
    {
        Task<int> AddAsync(IProject entity);
        Task<int> DeleteAsync(long id);
        Task<int> DeleteAsync(IProject entity);
        Task<int> UpdateAsync(IProject entity);
        Task<IProject> GetAsync(long id);
        IList<IProject> Find(IFindParams findParams);
    }
}
