using System.Threading.Tasks;
using Tasker.WebAPI.Controllers.Interface;
using Tasker.Service.Common;
using Tasker.Common.Find.Interface;
using Tasker.Common.Find;
using Tasker.Model.Common;
using Tasker.Model.FilterModels;
using System.Web.Http;

namespace Tasker.WebAPI.Controllers
{
    public class ProjectTaskController : ApiController, IProjectTaskController
    {
        private readonly IProjectTaskService _projectTaskService;

        //private readonly ITimeEntryService _timeEntryService;

        private const int RowNumber = 4;

        public ProjectTaskController(IProjectTaskService projectTaskService/*, ITimeEntryService timeEntryService*/)
        {
            this._projectTaskService = projectTaskService;
            //this._timeEntryService = timeEntryService;
        }

        public async Task<IHttpActionResult> Get(long id)
        {
            await _projectTaskService.Get(id);
            return Ok();
        }
        public async Task<IHttpActionResult> Find()
        {
            IFindParams fp = new FindParams(1, RowNumber, "Name", "desc");
            await _projectTaskService.Find(new ProjectTaskFilterParams { Name = "" }, fp);
            return Ok();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(IProjectTask projectTaskModel)
        {
            await _projectTaskService.AddAsync(projectTaskModel);
            return Ok();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Delete(IProjectTask projectTaskModel)
        {
            await _projectTaskService.DeleteAsync(projectTaskModel.Id);
            return Ok();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update(IProjectTask projectTaskModel)
        {
            await _projectTaskService.UpdateAsync(projectTaskModel);
            return Ok();
        }

        //public async Task<ActionResult> Details(long id, string searchString, TimeSpan? searchTime,
        //    string searchProperty, int? pageNumber, string sortBy, string sortDirection)
        //{

        //    int pn = pageNumber ?? 1;
        //    IFindParams fp = new FindParams(id, pn, RowNumber, sortBy, sortDirection);
        //    IPagedList<ITimeEntry> timeEntries = new PagedList<ITimeEntry>(Enumerable.Empty<TimeEntry>(), 1, 1);
        //    if (String.IsNullOrEmpty(searchProperty))
        //        timeEntries = await _timeEntryService.Find(null, fp);
        //    else if (searchProperty == "Name")
        //        timeEntries = await _timeEntryService.Find(new TimeEntryFilterParams { Name = searchString }, fp);
        //    else if (searchProperty == "TimeSpent")
        //        timeEntries = await _timeEntryService.Find(new TimeEntryFilterParams { TimeSpent = searchTime }, fp);
        //    else if (searchProperty == "Description")
        //        timeEntries = await _timeEntryService.Find(new TimeEntryFilterParams { Description = searchString }, fp);

        //    ViewBag.sortByTimeEntry = sortBy;
        //    ViewBag.sortDirectionTimeEntry = sortDirection;

        //    IProjectTask projectTaskModel = await _projectTaskService.Get(id);
        //    if (projectTaskModel == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.NotFound);

        //    StaticPagedList<ITimeEntry> pagedDetailModel =
        //        new StaticPagedList<ITimeEntry>(timeEntries, timeEntries.GetMetaData());
        //    projectTaskModel.TimeEntriesPaged = pagedDetailModel;


        //    return View(projectTaskModel);
        //}
    }
}