using System.Threading.Tasks;
using Tasker.WebAPI.Controllers.Interface;
using Tasker.Service.Common;
using Tasker.Model.Common;
using System.Web.Http;
using Tasker.Model.FilterModels;
using Tasker.Common.Find.Interface;
using Tasker.Common.Find;

namespace Tasker.WebAPI.Controllers
{
    public class ProjectController : ApiController, IProjectController
    {
        private readonly IProjectService _projectService;

        //private readonly IProjectTaskService _projectTaskService;

        private const int RowNumber = 4;

        public ProjectController(IProjectService projectService/*, IProjectTaskService projectTaskService*/)
        {
            this._projectService = projectService;
            //this._projectTaskService = projectTaskService;
        }

        public async Task<IHttpActionResult> Get(long id)
        {
            await _projectService.Get(id);
            return Ok();
        }
        public async Task<IHttpActionResult> Find()
        {
            IFindParams fp = new FindParams(1, RowNumber, "Name", "desc");
            await _projectService.Find(new ProjectFilterParams { Name = "" }, fp);
            return Ok();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(IProject projectModel)
        {
            await _projectService.AddAsync(projectModel);
            return Ok();

        }

        [HttpPost]
        public async Task<IHttpActionResult> Delete(long id)
        {
            //Project project = await _projectService.Get(id);
            //if (project == null)
            //    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            await _projectService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update(IProject projectModel)
        {
            await _projectService.UpdateAsync(projectModel);
            //Response.StatusCode = 200;
            return Ok();
        }
        //public async Task<IHttpActionResult> Index(string searchString, int? searchInt, DateTime? searchDate,
        //    bool? searchBool, string searchProperty, int? pageNumber, string sortBy, string sortDirection)
        //{

        //    int pn = pageNumber ?? 1;
        //    IFindParams fp = new FindParams(pn, RowNumber, sortBy, sortDirection);
        //    IPagedList<IProject> projects = new PagedList<IProject>(Enumerable.Empty<Project>(), 1, 1);
        //    if (String.IsNullOrEmpty(searchProperty))
        //        projects = await _projectService.Find(null, fp);
        //    else if (searchProperty == "Name")
        //        projects = await _projectService.Find(new ProjectFilterParams { Name = searchString}, fp);
        //    else if (searchProperty == "DueDate")
        //        projects = await _projectService.Find(new ProjectFilterParams { DueDate = searchDate }, fp);
        //    else if (searchProperty == "Priority" && searchInt != null)
        //        projects = await _projectService.Find(new ProjectFilterParams { Priority = (PriorityLevel) searchInt }, fp);
        //    else if (searchProperty == "Completed" && searchBool != null)
        //        projects = await _projectService.Find(new ProjectFilterParams { Completed = searchBool }, fp);
        //    else if (searchProperty == "Description")
        //        projects = await _projectService.Find(new ProjectFilterParams { Description = searchString }, fp);

        //    StaticPagedList<IProject> pagedViewModel =
        //        new StaticPagedList<IProject>(projects, projects.GetMetaData());

        //    return Ok();
        //}


        //public async Task<IHttpActionResult> Details(long id, string searchString, int? searchInt, DateTime? searchDate,
        //    bool? searchBool, TimeSpan? searchTime, string searchProperty, int? pageNumber, string sortBy, string sortDirection)
        //{

        //    int pn = pageNumber ?? 1;
        //    IFindParams fp = new FindParams(id, pn, RowNumber, sortBy, sortDirection);
        //    IPagedList<IProjectTask> projectTasks = new PagedList<IProjectTask>(Enumerable.Empty<IProjectTask>(), 1, 1);
        //    if (String.IsNullOrEmpty(searchProperty))
        //        projectTasks = await _projectTaskService.Find(null, fp);
        //    else if (searchProperty == "Name")
        //        projectTasks = await _projectTaskService.Find(new ProjectTaskFilterParams { Name = searchString }, fp);
        //    else if (searchProperty == "DueDate")
        //        projectTasks = await _projectTaskService.Find(new ProjectTaskFilterParams { DueDate = searchDate }, fp);
        //    else if (searchProperty == "Priority" && searchInt != null)
        //        projectTasks = await _projectTaskService.Find(new ProjectTaskFilterParams { Priority = (PriorityLevel) searchInt }, fp);
        //    else if (searchProperty == "EstimatedTime")
        //        projectTasks = await _projectTaskService.Find(new ProjectTaskFilterParams { EstimatedTime = searchTime }, fp);
        //    else if (searchProperty == "Completed" && searchBool != null)
        //        projectTasks = await _projectTaskService.Find(new ProjectTaskFilterParams { Completed = searchBool }, fp);
        //    else if (searchProperty == "Description")
        //        projectTasks = await _projectTaskService.Find(new ProjectTaskFilterParams { Description = searchString }, fp);

        //    IProject projectTaskModel = await _projectService.Get(id);
        //    if (projectTaskModel == null)
        //        return new HttpResponseMessage(HttpStatusCode.NotFound);

        //    StaticPagedList<IProjectTask> pagedViewModel =
        //        new StaticPagedList<IProjectTask>(projectTasks, projectTasks.GetMetaData());
        //    projectTaskModel.TasksPaged = pagedViewModel;

        //    return Ok();
        //}

    }
}