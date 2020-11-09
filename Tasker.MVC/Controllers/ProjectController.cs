using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Ninject.Activation;
using Tasker.Service.DataAccess.Interface;
using Tasker.Service.Models;
using Tasker.MVC.Controllers.Interface;
using Tasker.MVC.Models;
using Tasker.MVC.Models.Interface;
using Tasker.Service;
using Tasker.Service.Service.Interface;
using System.Diagnostics;
using Microsoft.Ajax.Utilities;
using PagedList;
using System.Web.UI.WebControls;
using System.Web.Http.Results;

namespace Tasker.MVC.Controllers
{
    public class ProjectController : Controller, IProjectController
    {
        private readonly IProjectService _projectService;

        private readonly IProjectTaskService _projectTaskService;

        private readonly IMapper _mapper;

        private const int RowNumber = 4;

        public ProjectController(IProjectService projectService, IProjectTaskService projectTaskService,
            IMapper mapper)
        {
            this._projectService = projectService;
            this._projectTaskService = projectTaskService;
            this._mapper = mapper;
        }

        public async Task<ActionResult> Index(string searchString, int? searchInt, DateTime? searchDate,
            bool? searchBool, string searchProperty, int? pageNumber, string sortBy, string sortDirection)
        {
            (searchString, searchInt, searchDate, searchBool, searchProperty, pageNumber, sortBy, sortDirection) =
                TempView(searchString, searchInt, searchDate, searchBool, searchProperty, pageNumber, sortBy, sortDirection);


            int pn = pageNumber ?? 1;
            IPagedList<Project> projects = new PagedList<Project>(Enumerable.Empty<Project>(), 1, 1);
            if (String.IsNullOrEmpty(searchString) && searchInt == null && String.IsNullOrEmpty(searchProperty))
                projects = await _projectService.Filter("", "", pn, RowNumber, sortBy, sortDirection);
            else if (!String.IsNullOrEmpty(searchString))
                projects = await _projectService.Filter(searchProperty, searchString, pn, RowNumber, sortBy, sortDirection);
            else if (searchInt != null)
                projects = await _projectService.Filter(searchProperty, searchInt, pn, RowNumber, sortBy, sortDirection);
            else if (searchProperty == "DueDate")
                projects = await _projectService.Filter(searchProperty, searchDate, pn, RowNumber, sortBy, sortDirection);
            else if (searchBool != null && searchProperty == "Completed")
                projects = await _projectService.Filter(searchProperty, searchBool, pn, RowNumber, sortBy, sortDirection);

            ViewBag.sortBy = sortBy;
            ViewBag.sortDirection = sortDirection;

            StaticPagedList<ProjectModel> pagedViewModel =
                new StaticPagedList<ProjectModel>(_mapper.Map<IEnumerable<Project>, List<ProjectModel>>(projects), projects.GetMetaData());

            return View(pagedViewModel);
        }


        public ActionResult Create()
        {
            return View();
        }
        public async Task<ActionResult> Delete(long id)
        {
            return View(_mapper.Map<Project, ProjectModel>(await _projectService.Get(id)));
        }

        public async Task<ActionResult> Update(long id)
        {
            return View(_mapper.Map<Project, ProjectModel>(await _projectService.Get(id)));
        }

        public async Task<ActionResult> Details(long id, string searchString, int? searchInt, DateTime? searchDate,
            bool? searchBool, TimeSpan? searchTime, string searchProperty, int? pageNumber, string sortBy, string sortDirection)
        {

            (searchString, searchInt, searchDate, searchBool, searchTime, searchProperty, pageNumber, sortBy, sortDirection)
                = TempDetail(id, searchString, searchInt, searchDate, searchBool, searchTime, searchProperty, pageNumber, sortBy, sortDirection);


            int pn = pageNumber ?? 1;
            IPagedList<ProjectTask> projectTasks = new PagedList<ProjectTask>(Enumerable.Empty<ProjectTask>(), 1, 1);
            if (String.IsNullOrEmpty(searchString) && searchInt == null && String.IsNullOrEmpty(searchProperty))
                projectTasks = await _projectTaskService.Filter(id, "", "", pn, RowNumber, sortBy, sortDirection);
            else if (!String.IsNullOrEmpty(searchString))
                projectTasks = await _projectTaskService.Filter(id, searchProperty, searchString, pn, RowNumber, sortBy, sortDirection);
            else if (searchInt != null)
                projectTasks = await _projectTaskService.Filter(id, searchProperty, searchInt, pn, RowNumber, sortBy, sortDirection);
            else if (searchProperty == "DueDate")
                projectTasks = await _projectTaskService.Filter(id, searchProperty, searchDate, pn, RowNumber, sortBy, sortDirection);
            else if (searchBool != null && searchProperty == "Completed")
                projectTasks = await _projectTaskService.Filter(id, searchProperty, searchBool, pn, RowNumber, sortBy, sortDirection);
            else if (searchProperty == "EstimatedTime")
                projectTasks = await _projectTaskService.Filter(id, searchProperty, searchTime, pn, RowNumber, sortBy, sortDirection);

            ViewBag.sortByTasks = sortBy;
            ViewBag.sortDirectionTasks = sortDirection;

            ProjectModel projectTaskModel = _mapper.Map<Project, ProjectModel>(await _projectService.Get(id));
            if (projectTaskModel == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            StaticPagedList<ProjectTaskModel> pagedViewModel =
                new StaticPagedList<ProjectTaskModel>(_mapper.Map<IEnumerable<ProjectTask>, List<ProjectTaskModel>>(projectTasks), projectTasks.GetMetaData());
            projectTaskModel.TasksPaged = pagedViewModel;

            return View(projectTaskModel);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateModel(ProjectModel projectModel)
        {
            Project project = _mapper.Map<ProjectModel, Project>(projectModel);

            await _projectService.Create(project);
            return RedirectToAction("Index");

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteModel(long id)
        {
            //Project project = await _projectService.Get(id);
            //if (project == null)
            //    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            await _projectService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateModel(ProjectModel projectModel)
        {
            await _projectService.Update(_mapper.Map<ProjectModel, Project>(projectModel));
            //Response.StatusCode = 200;
            return RedirectToAction("Details", new { id = projectModel.Id });
        }
        private (string, int?, DateTime?, bool?, string, int?, string, string) TempView(string searchString, int? searchInt,
           DateTime? searchDate, bool? searchBool, string searchProperty, int? pageNumber, string sortBy, string sortDirection)
        {
            // TempData - sortBy
            if (sortBy != null)
            {
                TempData["sortBy"] = sortBy;
            }
            else
            {
                sortBy = TempData["sortBy"] != null ? TempData["sortBy"].ToString() : null;
                ViewBag.sortBy = sortBy;
            }
            // TempData - sortDirection
            if (sortDirection != null)
            {
                TempData["sortDirection"] = sortDirection;
            }
            else
            {

                sortDirection = TempData["sortDirection"] != null ? TempData["sortDirection"].ToString() : null;
                ViewBag.sortDirection = sortDirection;
            }
            // TempData - searchProperty
            if (searchProperty != null)
            {
                TempData["searchProperty"] = searchProperty;
            }
            else
            {
                searchProperty = TempData["searchProperty"] != null ? TempData["searchProperty"].ToString() : null;
                ViewBag.searchProperty = searchProperty;
            }
            // TempData - pageNumber
            if (pageNumber != null)
            {
                TempData["pageNumber"] = pageNumber;
            }
            else
            {
                pageNumber = TempData["pageNumber"] != null ? (int?)TempData["pageNumber"] : null;
                ViewBag.pageNumber = pageNumber;
            }
            if (String.IsNullOrEmpty(searchProperty))
            {
                TempData.Keep();
                return (searchString, searchInt, searchDate, searchBool, searchProperty, pageNumber, sortBy, sortDirection);
            }


            // TempData - searchString
            if (searchString != null)
            {
                TempData["searchString"] = searchString;
            }
            else
            {
                searchString = TempData["searchString"] != null ? TempData["searchString"].ToString() : null;
                ViewBag.searchString = searchString;
            }
            // TempData - searchInt
            if (searchInt != null)
            {
                TempData["searchInt"] = searchInt;
            }
            else
            {
                searchInt = TempData["searchInt"] != null ? (int?)TempData["searchInt"] : null;
                ViewBag.searchInt = searchInt;
            }
            // TempData - searchDate
            if (searchDate != null)
            {
                TempData["searchDate"] = searchDate;
            }
            else
            {
                searchDate = TempData["searchDate"] != null ? (DateTime?)TempData["searchDate"] : null;
                ViewBag.searchDate = searchDate;
            }
            // TempData - searchBool
            if (searchBool != null)
            {
                TempData["searchBool"] = searchBool;
            }
            else
            {
                searchBool = TempData["searchBool"] != null ? (bool?)TempData["searchBool"] : null;
                ViewBag.searchBool = searchBool;
            }
            TempData.Keep();
            return (searchString, searchInt, searchDate, searchBool, searchProperty, pageNumber, sortBy, sortDirection);
        }
        private (string searchString, int? searchInt, DateTime? searchDate, bool? searchBool, TimeSpan? searchTime,
            string searchProperty, int? pageNumber, string, string) TempDetail(long id, string searchString, int? searchInt,
            DateTime? searchDate, bool? searchBool, TimeSpan? searchTime, string searchProperty, int? pageNumber, string sortBy, string sortDirection)
        {
            if (TempData["projectId"] == null)
            {
                TempData["projectId"] = id;
            }
            else
            {
                if ((long)TempData["projectId"] != id)
                {
                    TempData["projectId"] = id;
                    TempData["searchPropertyTasks"] = null;
                    TempData["pageNumberTasks"] = null;
                    TempData["searchStringTasks"] = null;
                    TempData["searchIntTasks"] = null;
                    TempData["searchDateTasks"] = null;
                    TempData["searchBoolTasks"] = null;
                    TempData["searchTimeTasks"] = null;
                    TempData["sortByTasks"] = null;
                    TempData["sortDirectionTasks"] = null;
                }
            }
            // TempData - sortBy
            if (sortBy != null)
            {
                TempData["sortByTasks"] = sortBy;
            }
            else
            {
                sortBy = TempData["sortByTasks"] != null ? TempData["sortByTasks"].ToString() : null;
                ViewBag.sortByTasks = sortBy;
            }
            // TempData - sortDirection
            if (sortDirection != null)
            {
                TempData["sortDirectionTasks"] = sortDirection;
            }
            else
            {
                sortDirection = TempData["sortDirectionTasks"] != null ? TempData["sortDirectionTasks"].ToString() : null;
                ViewBag.sortDirectionTasks = sortDirection;
            }
            // TempData - searchProperty
            if (searchProperty != null)
            {
                TempData["searchPropertyTasks"] = searchProperty;
            }
            else
            {
                searchProperty = TempData["searchPropertyTasks"] != null ? TempData["searchPropertyTasks"].ToString() : null;
                ViewBag.searchProperty = searchProperty;
            }
            // TempData - pageNumber
            if (pageNumber != null)
            {
                TempData["pageNumberTasks"] = pageNumber;
            }
            else
            {
                pageNumber = TempData["pageNumberTasks"] != null ? (int?)TempData["pageNumberTasks"] : null;
                ViewBag.pageNumber = pageNumber;
            }
            if (String.IsNullOrEmpty(searchProperty))
            {
                TempData.Keep();
                return (searchString, searchInt, searchDate, searchBool, searchTime, searchProperty, pageNumber, sortBy, sortDirection);
            }
            // TempData - searchString
            if (searchString != null)
            {
                TempData["searchStringTasks"] = searchString;
            }
            else
            {
                searchString = TempData["searchStringTasks"] != null ? TempData["searchStringTasks"].ToString() : null;
                ViewBag.searchString = searchString;
            }
            // TempData - searchInt
            if (searchInt != null)
            {
                TempData["searchIntTasks"] = searchInt;
            }
            else
            {
                searchInt = TempData["searchIntTasks"] != null ? (int?)TempData["searchIntTasks"] : null;
                ViewBag.searchInt = searchInt;
            }
            // TempData - searchDate
            if (searchDate != null)
            {
                TempData["searchDateTasks"] = searchDate;
            }
            else
            {
                searchDate = TempData["searchDateTasks"] != null ? (DateTime?)TempData["searchDateTasks"] : null;
                ViewBag.searchDate = searchDate;
            }
            // TempData - searchBool
            if (searchBool != null)
            {
                TempData["searchBoolTasks"] = searchBool;
            }
            else
            {
                searchBool = TempData["searchBoolTasks"] != null ? (bool?)TempData["searchBoolTasks"] : null;
                ViewBag.searchBool = searchBool;
            }
            // TempData - searchTime
            if (searchTime != null)
            {
                TempData["searchTimeTasks"] = searchTime;
            }
            else
            {
                searchTime = TempData["searchTimeTasks"] != null ? (TimeSpan?)TempData["searchTimeTasks"] : null;
                ViewBag.searchTime = searchTime;
            }
            TempData.Keep();
            return (searchString, searchInt, searchDate, searchBool, searchTime, searchProperty, pageNumber, sortBy, sortDirection);
        }
    }
}