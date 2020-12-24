using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Tasker.Common.Find;
using Tasker.Common.Find.Interface;
using Tasker.Model.Common;
using Tasker.Service.Common;
using Tasker.WebAPI.Controllers.Interface;
using Tasker.WebAPI.Models;

namespace Tasker.WebAPI.Controllers
{
    /// <summary>
    /// Time Entry information
    /// </summary>
    public class TimeEntryController : ApiController, IBaseController<TimeEntryView>
    {
        private readonly ITimeEntryService _timeEntryService;
        private protected readonly IMapper _mapper;

        private const int RowNumber = 4;

        public TimeEntryController(ITimeEntryService timeEntryService, IMapper mapper)
        {
            this._timeEntryService = timeEntryService;
            this._mapper = mapper;
        }
        /// <summary>
        /// Gets Time Entry by id
        /// </summary>
        /// <param name="id">Unique identifier for Time Entry</param>
        /// <returns>Time Entry</returns>
        [Route("api/TimeEntry/Get/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(long id)
        {
            return Ok(_mapper.Map<TimeEntryView>(await _timeEntryService.Get(id)));
        }
        /// <summary>
        /// Finds Time Entry by filter, sort and paging parameters
        /// </summary>
        /// <param name="id">Parent id</param>
        /// <param name="pageNumber">Current page</param>
        /// <param name="filterBy">Filtering parameter</param>
        /// <param name="filterCondition">Filtering string</param>
        /// <param name="sortBy">Sort parameter</param>
        /// <param name="sortDirection">Sort order</param>
        /// <returns>List of Time Entries</returns>
        [Route("api/TimeEntry/Find")]
        [HttpGet]
        public async Task<IHttpActionResult> Find(long? id, int? pageNumber, string filterBy, string filterCondition, string sortBy, string sortDirection)
        {
            IFindParams fp = new FindParams(id, pageNumber, filterBy, filterCondition, RowNumber, sortBy, sortDirection);
            ;
            return Ok(_mapper.Map<IList<ProjectTaskView>>(await _timeEntryService.Find(fp)));
        }
        /// <summary>
        /// Creates new Time Entry
        /// </summary>
        /// <param name="timeEntryViewModel">Time Entry view model</param>
        /// <returns>Http status</returns>
        [Route("api/TimeEntry/Create")]
        [HttpPost]
        public async Task<IHttpActionResult> Create(TimeEntryView timeEntryViewModel)
        {
            _timeEntryService.ValidateModel(_mapper.Map<ITimeEntry>(timeEntryViewModel), ModelState.AddModelError);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _timeEntryService.AddAsync(Mapper.Map<ITimeEntry>(timeEntryViewModel));
            return Ok();
        }
        /// <summary>
        /// Deletes Time Entry
        /// </summary>
        /// <param name="id">Unique identifier for Time Entry</param>
        /// <returns>Http Status</returns>
        [Route("api/TimeEntry/Delete/{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(long id)
        {
            try
            {
                _mapper.Map<ITimeEntry>(await _timeEntryService.DeleteAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
        /// <summary>
        /// Updates Time Entry
        /// </summary>
        /// <param name="timeEntryViewModel">Time Entry view model</param>
        /// <returns>Http status</returns>
        [Route("api/TimeEntry/Update")]
        [HttpPut]
        public async Task<IHttpActionResult> Update(TimeEntryView timeEntryViewModel)
        {
            _timeEntryService.ValidateModel(_mapper.Map<ITimeEntry>(timeEntryViewModel), ModelState.AddModelError);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _timeEntryService.UpdateAsync(Mapper.Map<ITimeEntry>(timeEntryViewModel));
            return Ok();
        }
    }
}