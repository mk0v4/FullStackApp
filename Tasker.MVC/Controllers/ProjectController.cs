using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Tasker.WebAPI.Controllers.Interface;
using PagedList;
using Tasker.Service.Common;
using Tasker.Common.Find;
using Tasker.Common.Find.Interface;
using Tasker.Common.Enums;
using Tasker.Model.Common;
using Tasker.Model;
using Tasker.Model.FilterModels;

namespace Tasker.WebAPI.Controllers
{
    public class ProjectController : Controller, IProjectController
    {
        private readonly IProjectService _projectService;

        private readonly IProjectTaskService _projectTaskService;

        private const int RowNumber = 4;

        public ProjectController(IProjectService projectService, IProjectTaskService projectTaskService)
        {
            this._projectService = projectService;
            this._projectTaskService = projectTaskService;
        }

        public async Task<ActionResult> Index(string searchString, int? searchInt, DateTime? searchDate,
            bool? searchBool, string searchProperty, int? pageNumber, string sortBy, string sortDirection)
        {

            int pn = pageNumber ?? 1;
            IFindParams fp = new FindParams(pn, RowNumber, sortBy, sortDirection);
            IPagedList<IProject> projects = new PagedList<IProject>(Enumerable.Empty<Project>(), 1, 1);
            if (String.IsNullOrEmpty(searchProperty))
                projects = await _projectService.Find(null, fp);
            else if (searchProperty == "Name")
                projects = await _projectService.Find(new ProjectFilterParams { Name = searchString}, fp);
            else if (searchProperty == "DueDate")
                projects = await _projectService.Find(new ProjectFilterParams { DueDate = searchDate }, fp);
            else if (searchProperty == "Priority" && searchInt != null)
                projects = await _projectService.Find(new ProjectFilterParams { Priority = (PriorityLevel) searchInt }, fp);
            else if (searchProperty == "Completed" && searchBool != null)
                projects = await _projectService.Find(new ProjectFilterParams { Completed = searchBool }, fp);
            else if (searchProperty == "Description")
                projects = await _projectService.Find(new ProjectFilterParams { Description = searchString }, fp);

            ViewBag.sortBy = sortBy;
            ViewBag.sortDirection = sortDirection;

            StaticPagedList<IProject> pagedViewModel =
                new StaticPagedList<IProject>(projects, projects.GetMetaData());

            return View(pagedViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }
        public async Task<ActionResult> Delete(long id)
        {
            return View(await _projectService.Get(id));
        }

        public async Task<ActionResult> Update(long id)
        {
            return View(await _projectService.Get(id));
        }

        public async Task<ActionResult> Details(long id, string searchString, int? searchInt, DateTime? searchDate,
            bool? searchBool, TimeSpan? searchTime, string searchProperty, int? pageNumber, string sortBy, string sortDirection)
        {

            int pn = pageNumber ?? 1;
            IFindParams fp = new FindParams(id, pn, RowNumber, sortBy, sortDirection);
            IPagedList<IProjectTask> projectTasks = new PagedList<IProjectTask>(Enumerable.Empty<IProjectTask>(), 1, 1);
            if (String.IsNullOrEmpty(searchProperty))
                projectTasks = await _projectTaskService.Find(null, fp);
            else if (searchProperty == "Name")
                projectTasks = await _projectTaskService.Find(new ProjectTaskFilterParams { Name = searchString }, fp);
            else if (searchProperty == "DueDate")
                projectTasks = await _projectTaskService.Find(new ProjectTaskFilterParams { DueDate = searchDate }, fp);
            else if (searchProperty == "Priority" && searchInt != null)
                projectTasks = await _projectTaskService.Find(new ProjectTaskFilterParams { Priority = (PriorityLevel) searchInt }, fp);
            else if (searchProperty == "EstimatedTime")
                projectTasks = await _projectTaskService.Find(new ProjectTaskFilterParams { EstimatedTime = searchTime }, fp);
            else if (searchProperty == "Completed" && searchBool != null)
                projectTasks = await _projectTaskService.Find(new ProjectTaskFilterParams { Completed = searchBool }, fp);
            else if (searchProperty == "Description")
                projectTasks = await _projectTaskService.Find(new ProjectTaskFilterParams { Description = searchString }, fp);

            ViewBag.sortByTasks = sortBy;
            ViewBag.sortDirectionTasks = sortDirection;

            IProject projectTaskModel = await _projectService.Get(id);
            if (projectTaskModel == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            StaticPagedList<IProjectTask> pagedViewModel =
                new StaticPagedList<IProjectTask>(projectTasks, projectTasks.GetMetaData());
            projectTaskModel.TasksPaged = pagedViewModel;

            return View(projectTaskModel);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateModel(IProject projectModel)
        {
            await _projectService.AddAsync(projectModel);
            return RedirectToAction("Index");

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteModel(long id)
        {
            //Project project = await _projectService.Get(id);
            //if (project == null)
            //    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            await _projectService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateModel(IProject projectModel)
        {
            await _projectService.UpdateAsync(projectModel);
            //Response.StatusCode = 200;
            return RedirectToAction("Details", new { id = projectModel.Id });
        }
    }
}