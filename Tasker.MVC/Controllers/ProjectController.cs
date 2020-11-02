using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
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

namespace Tasker.MVC.Controllers
{
    public class ProjectController : Controller, IProjectController
    {
        private readonly IProjectService _projectService;

        private IMapper _mapper;

        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            this._projectService = projectService;
            this._mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            IEnumerable<Project> projects = await _projectService.GetAll();
            return View(_mapper.Map<IEnumerable<Project>, List<IProjectModel>>(projects));
        }

        public async Task<ActionResult> Create(Project project)
        {
            project = new Project();
            project.Name = "name";

            await _projectService.Create(project);

            //View();
            //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}