using System.Threading.Tasks;
using System.Web.Http;
using Tasker.Common.Find;
using Tasker.Common.Find.Interface;
using Tasker.Model.Common;
using Tasker.Model.FilterModels;
using Tasker.Service.Common;
using Tasker.WebAPI.Controllers.Interface;

namespace Tasker.WebAPI.Controllers
{
    public class TimeEntryController : ApiController, ITimeEntryController
    {
        private readonly ITimeEntryService _timeEntryService;

        private const int RowNumber = 4;

        public TimeEntryController(ITimeEntryService timeEntryService)
        {
            this._timeEntryService = timeEntryService;
        }

        public async Task<IHttpActionResult> Get(long id)
        {
            await _timeEntryService.Get(id);
            return Ok();
        }
        public async Task<IHttpActionResult> Find()
        {
            IFindParams fp = new FindParams(1, RowNumber, "Name", "desc");
            await _timeEntryService.Find(new TimeEntryFilterParams { Name = "" }, fp);
            return Ok();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(ITimeEntry timeEntryModel)
        {
            await _timeEntryService.AddAsync(timeEntryModel);
            return Ok();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Delete(ITimeEntry timeEntryModel)
        {
            await _timeEntryService.DeleteAsync(timeEntryModel.Id);
            return Ok();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update(ITimeEntry timeEntryModel)
        {
            await _timeEntryService.UpdateAsync(timeEntryModel);
            return Ok();
        }
    }
}