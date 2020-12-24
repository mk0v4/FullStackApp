using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tasker.Common.Find.Interface;
using Tasker.Model.Common;
using Tasker.Repository.Common;
using Tasker.Service.Common;

namespace Tasker.Service
{
    public class ProjectService : IProjectService
    {
        private protected IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<int> AddAsync(IProject project)
        {
            return await _projectRepository.AddAsync(project);
        }

        public async Task<int> DeleteAsync(long id)
        {
            return await _projectRepository.DeleteAsync(id);
        }

        public async Task<int> UpdateAsync(IProject project)
        {
            return await _projectRepository.UpdateAsync(project);
        }

        public async Task<IProject> Get(long id)
        {
            IProject project = await _projectRepository.GetAsync(id);
            if (project == null)
                throw new Exception("Entity not found!");
            return project;
        }
        public async Task<IList<IProject>> Find(IFindParams findParams)
        {
            return _projectRepository.Find(findParams);
        }
        public void ValidateModel(IProject project, Action<string, string> modelError)
        {
            if (project == null)
            {
                modelError("Model", "Model is null");
            }
        }
    }
}
