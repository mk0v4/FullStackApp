using System.Linq;
using System.Threading.Tasks;
using PagedList;
using Tasker.Service.DataAccess;
using Tasker.Service.DataAccess.Interface;
using Tasker.Service.FilterModels;
using Tasker.Service.FilterModels.Interface;
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
        public async Task<IPagedList<ProjectTask>> Find(IProjectTaskFilterParams projectTaskFilterParams, IFindParams findParams)
        {
            IQueryable<ProjectTask> source = Enumerable.Empty<ProjectTask>().AsQueryable();
            if (findParams.Id != null)
            {
                source = await base.GetAll();
                source = source.Where(p => p.ProjectId == findParams.Id);
            }
            source = new Filter<ProjectTask>(projectTaskFilterParams).FilterData(source);
            source = new Sort<ProjectTask>().SortData(findParams, source);
            return new Paging<ProjectTask>().PaginateData(findParams, source);
        }
    }
}
