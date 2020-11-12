using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Tasker.Service.Common;
using Tasker.Service.DataAccess;
using Tasker.Service.DataAccess.Interface;
using Tasker.Service.Models;
using Tasker.Service.Service.Interface;

namespace Tasker.Service.Service
{
    public class ProjectService : GenericDataService<Project>, IProjectService
    {
        public ProjectService(IApplicationDbContext context) : base(context)
        {
        }

        public async Task<int> Create(Project project)
        {
            return await base.Create<Project>(project);
        }

        public new async Task<int> Delete(long id)
        {
            return await base.Delete(id);
        }

        public async Task<Project> Update(Project project)
        {
            return await base.Update<Project>(project);
        }

        public new async Task<Project> Get(long id)
        {
            return await base.Get(id);

        }
        [Obsolete("Method is deprecated.", true)]
        public async Task<IPagedList<Project>> Filter(string property, object value, int? pageNumber, int pageSize, string sortBy, string sortDirection)
        {
            IQueryable<Project> source = await base.GetAll();
            return base.Filter(source, property, value, pageNumber, pageSize, sortBy, sortDirection);
        }

        public async Task<IPagedList<Project>> Filter(FilteringElements filteringElements)
        {
            IQueryable<Project> source = await base.GetAll();
            return base.Filter(source, filteringElements);
        }
    }
}
