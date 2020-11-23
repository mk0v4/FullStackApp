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

        public async Task<IPagedList<Project>> Find(FindParams findElements)
        {
            IQueryable<Project> source = await base.GetAll();
            Filter<Project> filter = new Filter<Project>(new ProjectFilterParams());
            Sort<Project> sort = new Sort<Project>();
            sort.SortData(findElements, filter.FilterData(findElements, source));
            Paging<Project> paging = new Paging<Project>();
            return paging.PaginateData(findElements, sort.SortData(findElements, filter.FilterData(findElements, source)));
        }
    }
}
