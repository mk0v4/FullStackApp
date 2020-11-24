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

        public async Task<IPagedList<Project>> Find(IProjectFilterParams projectFilterParams, IFindParams findParams)
        {
            IQueryable<Project> source = await base.GetAll();
            source = new Filter<Project>(projectFilterParams).FilterData(source);
            source = new Sort<Project>().SortData(findParams, source);
            return new Paging<Project>().PaginateData(findParams, source);
        }
    }
}
