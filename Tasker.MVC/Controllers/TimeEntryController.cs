using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Tasker.MVC.Controllers.Interface;
using Tasker.MVC.Models;
using Tasker.Service.Models;
using Tasker.Service.Service.Interface;

namespace Tasker.MVC.Controllers
{
    public class TimeEntryController : Controller, ITimeEntryController
    {
        private readonly ITimeEntryService _timeEntryService;

        private readonly IMapper _mapper;

        public TimeEntryController(ITimeEntryService timeEntryService, IMapper mapper)
        {
            this._timeEntryService = timeEntryService;
            this._mapper = mapper;
        }

        public ActionResult Create(long taskId)
        {
            TimeEntryModel timeEntryModel = new TimeEntryModel();
            timeEntryModel.ProjectTaskId = taskId;
            return View(timeEntryModel);
        }

        public async Task<ActionResult> Delete(long id)
        {
            return View(_mapper.Map<TimeEntry, TimeEntryModel>(await _timeEntryService.Get(id)));
        }

        public async Task<ActionResult> Update(long id)
        {
            return View(_mapper.Map<TimeEntry, TimeEntryModel>(await _timeEntryService.Get(id)));
        }

        public async Task<ActionResult> Details(long id)
        {
            return View(_mapper.Map<TimeEntry, TimeEntryModel>(await _timeEntryService.Get(id)));
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateModel(TimeEntryModel timeEntryModelModel)
        {
            TimeEntry timeEntry = _mapper.Map<TimeEntryModel, TimeEntry>(timeEntryModelModel);
            await _timeEntryService.Create(timeEntry);
            return RedirectToAction("Details", "ProjectTask", new { id = timeEntryModelModel.ProjectTaskId });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteModel(TimeEntryModel timeEntryModel)
        {
            await _timeEntryService.Delete(timeEntryModel.Id);
            return RedirectToAction("Details", "ProjectTask", new { id = timeEntryModel.ProjectTaskId });
        }

        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateModel(TimeEntryModel timeEntryModel)
        {
            await _timeEntryService.Update(_mapper.Map<TimeEntryModel, TimeEntry>(timeEntryModel));
            return RedirectToAction("Details", new { id = timeEntryModel.Id });
        }
    }
}