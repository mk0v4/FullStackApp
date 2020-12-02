using System;
using System.Linq;
using System.Threading.Tasks;
using PagedList;
using Tasker.Common.Find;
using Tasker.Common.Find.Interface;
using Tasker.Model;
using Tasker.Model.Common;
using Tasker.Model.Common.FilterModels;
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
            IProject project = await _projectRepository.Get(id);
            if (project == null)
                throw new Exception("Entity not found!");
            return project;
        }
        public async Task<IPagedList<IProject>> Find(IProjectFilterParams projectFilterParams, IFindParams findParams)
        {
            IQueryable<Project> source = (IQueryable<Project>) await _projectRepository.GetAll();
            source = new Filter<Project>(projectFilterParams).FilterData(source);
            source = new Sort<Project>().SortData(findParams, source);
            return new Paging<Project>().PaginateData(findParams, source);
        }

    }
}
