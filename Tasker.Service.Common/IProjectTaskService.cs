using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tasker.Common.Find.Interface;
using Tasker.Model.Common;

namespace Tasker.Service.Common
{
    public interface IProjectTaskService
    {
        Task<int> AddAsync(IProjectTask project);
        Task<IProjectTask> Get(long id);
        Task<int> DeleteAsync(long id);
        Task<int> UpdateAsync(IProjectTask project);
        Task<IList<IProjectTask>> Find(IFindParams findParams);
        void ValidateModel(IProjectTask project, Action<string, string> AddModelError);
    }
}