using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedList;
using Tasker.Service.DataAccess;
using Tasker.Service.Models;

namespace Tasker.Service.Service.Interface
{
    public interface IProjectTaskService
    {
        Task<int> Create(ProjectTask project);
        Task<ProjectTask> Get(long id);
        Task<int> Delete(long id);
        Task<ProjectTask> Update(ProjectTask project);
        [Obsolete("Method is deprecated.", true)]
        Task<IPagedList<ProjectTask>> Filter(long? id, string property, object value, int? pageNumber, 
            int pageSize, string sortBy, string sortDirection);
        Task<IPagedList<ProjectTask>> Filter(FilteringElements filteringElements);
    }
}