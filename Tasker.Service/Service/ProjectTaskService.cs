using System;
using System.Collections.Generic;
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
    public class ProjectTaskService : GenericDataService<ProjectTask>, IProjectTaskService
    {
        public ProjectTaskService(IApplicationDbContext context) : base(context)
        {
        }

        public async Task<int> Create(ProjectTask projectTask)
        {
            return await base.Create<ProjectTask>(projectTask);
        }

        public new async Task<int> Delete(long id)
        {
            return await base.Delete(id);
        }

        public async Task<ProjectTask> Update(ProjectTask projectTask)
        {
            return await base.Update<ProjectTask>(projectTask);
        }

        public new async Task<ProjectTask> Get(long id)
        {
            return await base.Get(id);

        }
        public async Task<IPagedList<ProjectTask>> Filter(long? id, string property, object value, int? pageNumber, int pageSize, string sortBy, string sortDirection)
        {
            IQueryable<ProjectTask> source = Enumerable.Empty<ProjectTask>().AsQueryable();
            if (id != null)
            {
                source = await base.GetAll();
                source = source.Where(p => p.ProjectId == id);
            }
            return base.Filter(source, property, value, pageNumber, pageSize, sortBy, sortDirection);
        }
    }
}
