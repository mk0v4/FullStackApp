using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Tasker.WebAPI.Controllers.Interface;
using PagedList;
using Tasker.Service.Common;
using Tasker.Model;
using Tasker.Common.Find.Interface;
using Tasker.Common.Find;
using Tasker.Model.Common;
using Tasker.Model.FilterModels;

namespace Tasker.WebAPI.Controllers
{
    public class ProjectTaskController : Controller, IProjectTaskController
    {
        private readonly IProjectTaskService _projectTaskService;

        private readonly ITimeEntryService _timeEntryService;

        private const int RowNumber = 4;

        public ProjectTaskController(IProjectTaskService projectTaskService, ITimeEntryService timeEntryService)
        {
            this._projectTaskService = projectTaskService;
            this._timeEntryService = timeEntryService;
        }

        public ActionResult Create(long projectId)
        {
            ProjectTask projectTaskModel = new ProjectTask();
            projectTaskModel.ProjectId = projectId;
            return View(projectTaskModel);
        }
        public async Task<ActionResult> Delete(long id)
        {
            return View(await _projectTaskService.Get(id));
        }

        public async Task<ActionResult> Update(long id)
        {
            return View(await _projectTaskService.Get(id));
        }

        public async Task<ActionResult> Details(long id, string searchString, TimeSpan? searchTime,
            string searchProperty, int? pageNumber, string sortBy, string sortDirection)
        {

            int pn = pageNumber ?? 1;
            IFindParams fp = new FindParams(id, pn, RowNumber, sortBy, sortDirection);
            IPagedList<ITimeEntry> timeEntries = new PagedList<ITimeEntry>(Enumerable.Empty<TimeEntry>(), 1, 1);
            if (String.IsNullOrEmpty(searchProperty))
                timeEntries = await _timeEntryService.Find(null, fp);
            else if (searchProperty == "Name")
                timeEntries = await _timeEntryService.Find(new TimeEntryFilterParams { Name = searchString }, fp);
            else if (searchProperty == "TimeSpent")
                timeEntries = await _timeEntryService.Find(new TimeEntryFilterParams { TimeSpent = searchTime }, fp);
            else if (searchProperty == "Description")
                timeEntries = await _timeEntryService.Find(new TimeEntryFilterParams { Description = searchString }, fp);

            ViewBag.sortByTimeEntry = sortBy;
            ViewBag.sortDirectionTimeEntry = sortDirection;

            IProjectTask projectTaskModel = await _projectTaskService.Get(id);
            if (projectTaskModel == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            StaticPagedList<ITimeEntry> pagedDetailModel =
                new StaticPagedList<ITimeEntry>(timeEntries, timeEntries.GetMetaData());
            projectTaskModel.TimeEntriesPaged = pagedDetailModel;


            return View(projectTaskModel);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateModel(IProjectTask projectTaskModel)
        {
            await _projectTaskService.AddAsync(projectTaskModel);
            return RedirectToAction("Details", "Project", new { id = projectTaskModel.ProjectId });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteModel(IProjectTask projectTaskModel)
        {
            await _projectTaskService.DeleteAsync(projectTaskModel.Id);
            return RedirectToAction("Details", "Project", new { id = projectTaskModel.ProjectId });
        }

        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateModel(IProjectTask projectTaskModel)
        {
            await _projectTaskService.UpdateAsync(projectTaskModel);
            return RedirectToAction("Details", new { id = projectTaskModel.Id });
        }
    }
}