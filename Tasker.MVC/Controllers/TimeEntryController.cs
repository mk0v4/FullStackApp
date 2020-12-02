using System.Threading.Tasks;
using System.Web.Mvc;
using Tasker.Model;
using Tasker.Model.Common;
using Tasker.Service.Common;
using Tasker.WebAPI.Controllers.Interface;

namespace Tasker.WebAPI.Controllers
{
    public class TimeEntryController : Controller, ITimeEntryController
    {
        private readonly ITimeEntryService _timeEntryService;

        public TimeEntryController(ITimeEntryService timeEntryService)
        {
            this._timeEntryService = timeEntryService;
        }

        public ActionResult Create(long taskId)
        {
            TimeEntry timeEntryModel = new TimeEntry();
            timeEntryModel.ProjectTaskId = taskId;
            return View(timeEntryModel);
        }

        public async Task<ActionResult> Delete(long id)
        {
            return View(await _timeEntryService.Get(id));
        }

        public async Task<ActionResult> Update(long id)
        {
            return View(await _timeEntryService.Get(id));
        }

        public async Task<ActionResult> Details(long id)
        {
            return View(await _timeEntryService.Get(id));
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateModel(ITimeEntry timeEntryModel)
        {
            await _timeEntryService.AddAsync(timeEntryModel);
            return RedirectToAction("Details", "ProjectTask", new { id = timeEntryModel.ProjectTaskId });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteModel(ITimeEntry timeEntryModel)
        {
            await _timeEntryService.DeleteAsync(timeEntryModel.Id);
            return RedirectToAction("Details", "ProjectTask", new { id = timeEntryModel.ProjectTaskId });
        }

        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateModel(ITimeEntry timeEntryModel)
        {
            await _timeEntryService.UpdateAsync(timeEntryModel);
            return RedirectToAction("Details", new { id = timeEntryModel.Id });
        }
    }
}