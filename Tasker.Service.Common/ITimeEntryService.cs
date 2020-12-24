using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tasker.Common.Find.Interface;
using Tasker.Model.Common;

namespace Tasker.Service.Common
{
    public interface ITimeEntryService
    {
        Task<int> AddAsync(ITimeEntry project);
        Task<ITimeEntry> Get(long id);
        Task<int> DeleteAsync(long id);
        Task<int> UpdateAsync(ITimeEntry project);
        Task<IList<ITimeEntry>> Find(IFindParams findParams);
        void ValidateModel(ITimeEntry project, Action<string, string> AddModelError);
    }
}
