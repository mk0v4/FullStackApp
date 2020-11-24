using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Tasker.Service.Models;
using Tasker.MVC.Controllers.Interface;
using Tasker.MVC.Models;
using Tasker.Service.Service.Interface;
using PagedList;
using Tasker.Service.DataAccess;
using Tasker.Service.FilterModels;
using Tasker.Service.DataAccess.Interface;

namespace Tasker.MVC.Controllers
{
    public class ProjectTaskController : Controller, IProjectTaskController
    {
        private readonly IProjectTaskService _projectTaskService;

        private readonly ITimeEntryService _timeEntryService;

        private readonly IMapper _mapper;

        private const int RowNumber = 4;

        public ProjectTaskController(IProjectTaskService projectTaskService, ITimeEntryService timeEntryService, IMapper mapper)
        {
            this._projectTaskService = projectTaskService;
            this._timeEntryService = timeEntryService;
            this._mapper = mapper;
        }

        public ActionResult Create(long projectId)
        {
            ProjectTaskModel projectTaskModel = new ProjectTaskModel();
            projectTaskModel.ProjectId = projectId;
            return View(projectTaskModel);
        }
        public async Task<ActionResult> Delete(long id)
        {
            return View(_mapper.Map<ProjectTask, ProjectTaskModel>(await _projectTaskService.Get(id)));
        }

        public async Task<ActionResult> Update(long id)
        {
            return View(_mapper.Map<ProjectTask, ProjectTaskModel>(await _projectTaskService.Get(id)));
        }

        public async Task<ActionResult> Details(long id, string searchString, TimeSpan? searchTime,
            string searchProperty, int? pageNumber, string sortBy, string sortDirection)
        {

            (id, searchString, searchTime, searchProperty, pageNumber, sortBy, sortDirection)
                = TempDetail(id, searchString, searchTime, searchProperty, pageNumber, sortBy, sortDirection);

            int pn = pageNumber ?? 1;
            IFindParams fp = new FindParams(id, pn, RowNumber, sortBy, sortDirection);
            IPagedList<TimeEntry> timeEntries = new PagedList<TimeEntry>(Enumerable.Empty<TimeEntry>(), 1, 1);
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

            ProjectTaskModel projectTaskModel = _mapper.Map<ProjectTask, ProjectTaskModel>(await _projectTaskService.Get(id));
            if (projectTaskModel == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            StaticPagedList<TimeEntryModel> pagedDetailModel =
                new StaticPagedList<TimeEntryModel>(_mapper.Map<IEnumerable<TimeEntry>, List<TimeEntryModel>>(timeEntries), timeEntries.GetMetaData());
            projectTaskModel.TimeEntriesPaged = pagedDetailModel;


            return View(projectTaskModel);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateModel(ProjectTaskModel projectTaskModel)
        {
            ProjectTask projectTask = _mapper.Map<ProjectTaskModel, ProjectTask>(projectTaskModel);

            await _projectTaskService.Create(projectTask);
            return RedirectToAction("Details", "Project", new { id = projectTaskModel.ProjectId });

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteModel(ProjectTaskModel projectTaskModel)
        {
            await _projectTaskService.Delete(projectTaskModel.Id);
            return RedirectToAction("Details", "Project", new { id = projectTaskModel.ProjectId });
        }

        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateModel(ProjectTaskModel projectTaskModel)
        {
            await _projectTaskService.Update(_mapper.Map<ProjectTaskModel, ProjectTask>(projectTaskModel));
            return RedirectToAction("Details", new { id = projectTaskModel.Id });
        }

        private (long, string, TimeSpan?, string, int?, string, string) TempDetail(long id, string searchString, TimeSpan? searchTime,
            string searchProperty, int? pageNumber, string sortBy, string sortDirection)
        {
            if (TempData["projectTaskId"] == null)
            {
                TempData["projectTaskId"] = id;
            }
            else
            {
                if ((long)TempData["projectTaskId"] != id)
                {
                    TempData["projectTaskId"] = id;
                    TempData["searchPropertyTimeEntries"] = null;
                    TempData["pageNumberTimeEntries"] = null;
                    TempData["searchStringTimeEntries"] = null;
                    TempData["searchTimeTimeEntries"] = null;
                    TempData["sortByTimeEntries"] = null;
                    TempData["sortDirectionTimeEntries"] = null;
                }
            }
            // TempData - sortBy
            if (sortBy != null)
            {
                TempData["sortByTimeEntries"] = sortBy;
            }
            else
            {
                sortBy = TempData["sortByTimeEntries"] != null ? TempData["sortByTimeEntries"].ToString() : null;
                ViewBag.sortByTasks = sortBy;
            }
            // TempData - sortDirection
            if (sortDirection != null)
            {
                TempData["sortDirectionTimeEntries"] = sortDirection;
            }
            else
            {
                sortDirection = TempData["sortDirectionTimeEntries"] != null ? TempData["sortDirectionTimeEntries"].ToString() : null;
                ViewBag.sortDirectionTasks = sortDirection;
            }
            // TempData - searchProperty
            if (searchProperty != null)
            {
                TempData["searchPropertyTimeEntries"] = searchProperty;
            }
            else
            {
                searchProperty = TempData["searchPropertyTimeEntries"] != null ? TempData["searchPropertyTimeEntries"].ToString() : null;
                ViewBag.searchProperty = searchProperty;
            }
            // TempData - pageNumber
            if (pageNumber != null)
            {
                TempData["pageNumberTimeEntries"] = pageNumber;
            }
            else
            {
                pageNumber = TempData["pageNumberTimeEntries"] != null ? (int?)TempData["pageNumberTimeEntries"] : null;
                ViewBag.pageNumber = pageNumber;
            }
            if (String.IsNullOrEmpty(searchProperty))
            {
                TempData.Keep();
                return (id, searchString, searchTime, searchProperty, pageNumber, sortBy, sortDirection);
            }
            // TempData - searchString
            if (searchString != null)
            {
                TempData["searchStringTimeEntries"] = searchString;
            }
            else
            {
                searchString = TempData["searchStringTimeEntries"] != null ? TempData["searchStringTimeEntries"].ToString() : null;
                ViewBag.searchString = searchString;
            }
            // TempData - searchTime
            if (searchTime != null)
            {
                TempData["searchTimeTimeEntries"] = searchTime;
            }
            else
            {
                searchTime = TempData["searchTimeTimeEntries"] != null ? (TimeSpan?)TempData["searchTimeTimeEntries"] : null;
                ViewBag.searchTime = searchTime;
            }
            TempData.Keep();
            return (id, searchString, searchTime, searchProperty, pageNumber, sortBy, sortDirection);
        }
    }
}