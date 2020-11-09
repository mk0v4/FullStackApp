using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Tasker.Service.Models;

namespace Tasker.Service.Service.Interface
{
    public interface ITimeEntryService
    {
        Task<int> Create(TimeEntry project);
        Task<TimeEntry> Get(long id);
        Task<int> Delete(long id);
        Task<TimeEntry> Update(TimeEntry project);
        Task<IPagedList<TimeEntry>> Filter(long? id, string property, object value, int? pageNumber, int pageSize, string sortBy, string sortDirection);
    }
}
