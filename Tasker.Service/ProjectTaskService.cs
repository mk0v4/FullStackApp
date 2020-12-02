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
            return await _projectTaskRepository.Get(id);

        }
        public async Task<IPagedList<IProjectTask>> Find(IProjectTaskFilterParams projectTaskFilterParams, IFindParams findParams)
        {
            IQueryable<ProjectTask> source = Enumerable.Empty<ProjectTask>().AsQueryable();
            if (findParams.Id != null)
            {
                source = (IQueryable<ProjectTask>) await _projectTaskRepository.GetAll();
                source = source.Where(p => p.ProjectId == findParams.Id);
            }
            source = new Filter<ProjectTask>(projectTaskFilterParams).FilterData(source);
            source = new Sort<ProjectTask>().SortData(findParams, source);
            return new Paging<ProjectTask>().PaginateData(findParams, source);
        }
    }
}
