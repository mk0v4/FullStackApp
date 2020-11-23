using System.Linq;
using System.Threading.Tasks;
using PagedList;
using Tasker.Service.DataAccess;
using Tasker.Service.DataAccess.Interface;
using Tasker.Service.FilterModels;
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
        public async Task<IPagedList<ProjectTask>> Find(FindParams findElements)
        {
            IQueryable<ProjectTask> source = Enumerable.Empty<ProjectTask>().AsQueryable();
            if (findElements.Id != null)
            {
                source = await base.GetAll();
                source = source.Where(p => p.ProjectId == findElements.Id);
            }
            Filter<ProjectTask> filter = new Filter<ProjectTask>(new ProjectTaskFilterParams());
            Sort<ProjectTask> sort = new Sort<ProjectTask>();
            sort.SortData(findElements, filter.FilterData(findElements, source));
            Paging<ProjectTask> paging = new Paging<ProjectTask>();

            return paging.PaginateData(findElements, sort.SortData(findElements, filter.FilterData(findElements, source)));
        }
    }
}
