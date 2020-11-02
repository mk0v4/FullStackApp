using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Service.DataAccess.Interface;
using Tasker.Service.Models;
using Tasker.Service.Service.Interface;

namespace Tasker.Service.Service
{
    public class ProjectService : IProjectService
    {
        private IGenericDataService<Project> _projectService;

        public ProjectService(IGenericDataService<Project> projectService)
        {
            this._projectService = projectService;
        }
        
        public async Task<int> Create(Project project)
        {
            return await _projectService.Create<Project>(project);
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _projectService.GetAll();
        }
    }
}
