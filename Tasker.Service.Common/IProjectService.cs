using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tasker.Common.Find.Interface;
using Tasker.Model.Common;

namespace Tasker.Service.Common
{
    public interface IProjectService
    {
        Task<int> AddAsync(IProject project);
        Task<IProject> Get(long id);
        Task<int> DeleteAsync(long id);
        Task<int> UpdateAsync(IProject project);
        Task<IList<IProject>> Find(IFindParams findParams);
        void ValidateModel(IProject project, Action<string, string> AddModelError);
    }
}