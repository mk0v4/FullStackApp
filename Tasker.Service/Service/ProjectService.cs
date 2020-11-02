using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public new async Task<int> Delete(int id)
        {
            return await base.Delete(id);
        }

        public async Task<Project> Update(Project project)
        {
            return await base.Update<Project>(project);
        }

        public new async Task<Project> Get(int id)
        {
            return await base.Get(id);

        }

        public new async Task<IEnumerable<Project>> GetAll()
        {
            return await base.GetAll();
        }
    }
}
