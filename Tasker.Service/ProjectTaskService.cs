using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tasker.Common.Find.Interface;
using Tasker.Model.Common;
using Tasker.Repository.Common;
using Tasker.Service.Common;

namespace Tasker.Service
{
    public class ProjectTaskService : IProjectTaskService
    {
        private protected readonly IProjectTaskRepository _projectTaskRepository;
        public ProjectTaskService(IProjectTaskRepository projectRepository)
        {
            _projectTaskRepository = projectRepository;
        }

        public async Task<int> AddAsync(IProjectTask projectTask)
        {
            return await _projectTaskRepository.AddAsync(projectTask);
        }

        public async Task<int> DeleteAsync(long id)
        {
            return await _projectTaskRepository.DeleteAsync(id);
        }

        public async Task<int> UpdateAsync(IProjectTask projectTask)
        {
            return await _projectTaskRepository.UpdateAsync(projectTask);
        }

        public async Task<IProjectTask> Get(long id)
        {
            IProjectTask projectTaks = await _projectTaskRepository.GetAsync(id);
            if (projectTaks == null)
                throw new Exception("Entity not found!");
            return projectTaks;

        }
        public async Task<IList<IProjectTask>> Find(IFindParams findParams)
        {
            return _projectTaskRepository.Find(findParams);
        }
        public void ValidateModel(IProjectTask projectTask, Action<string, string> modelError)
        {
            if (projectTask == null)
            {
                modelError("Model", "Model is null");
            }
        }
    }
}
