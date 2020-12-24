using System.Threading.Tasks;
using Tasker.WebAPI.Controllers.Interface;
using Tasker.Service.Common;
using Tasker.Common.Find.Interface;
using Tasker.Common.Find;
using Tasker.Model.Common;
using System.Web.Http;
using AutoMapper;
using Tasker.WebAPI.Models;
using System.Collections.Generic;
using System;

namespace Tasker.WebAPI.Controllers
{
    /// <summary>
    /// Project Task information
    /// </summary>
    public class ProjectTaskController : ApiController, IBaseController<ProjectTaskView>
    {
        private readonly IProjectTaskService _projectTaskService;
        private protected readonly IMapper _mapper;

        private const int RowNumber = 4;

        public ProjectTaskController(IProjectTaskService projectTaskService, IMapper mapper)
        {
            this._projectTaskService = projectTaskService;
            this._mapper = mapper;
        }
        /// <summary>
        /// Get Project Task by id
        /// </summary>
        /// <param name="id">Unique identifier for Project Task</param>
        /// <returns>Project Task</returns>
        [Route("api/ProjectTask/Get/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(long id)
        {
            return Ok(_mapper.Map<ProjectTaskView>(await _projectTaskService.Get(id)));
        }
        /// <summary>
        /// Finds Projects by filter, sort and paging parameters
        /// </summary>
        /// <param name="id">Parent id</param>
        /// <param name="pageNumber">Current page</param>
        /// <param name="filterBy">Filtering parameter</param>
        /// <param name="filterCondition">Filtering string</param>
        /// <param name="sortBy">Sort parameter</param>
        /// <param name="sortDirection">Sort order</param>
        /// <returns>List of Project Tasks</returns>
        [Route("api/ProjectTask/Find")]
        [HttpGet]
        public async Task<IHttpActionResult> Find(long? id, int? pageNumber, string filterBy, string filterCondition, string sortBy, string sortDirection)
        {
            IFindParams fp = new FindParams(id, pageNumber, filterBy, filterCondition, RowNumber, sortBy, sortDirection);
            return Ok(_mapper.Map<IList<ProjectTaskView>>(await _projectTaskService.Find(fp)));
        }
        /// <summary>
        /// Creates new Project Task
        /// </summary>
        /// <param name="projectTaskViewModel"></param>
        /// <returns>Http status</returns>
        [Route("api/ProjectTask/Create")]
        [HttpPost]
        public async Task<IHttpActionResult> Create(ProjectTaskView projectTaskViewModel)
        {
            _projectTaskService.ValidateModel(_mapper.Map<IProjectTask>(projectTaskViewModel), ModelState.AddModelError);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _projectTaskService.AddAsync(_mapper.Map<IProjectTask>(projectTaskViewModel));
            return Ok();
        }
        /// <summary>
        /// Deletes Project Task
        /// </summary>
        /// <param name="id">Unique identifier for Project Task</param>
        /// <returns>Http status</returns>
        [Route("api/ProjectTask/Delete/{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(long id)
        {
            try
            {
                _mapper.Map<IProjectTask>(await _projectTaskService.DeleteAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
        /// <summary>
        /// Updates Project Task
        /// </summary>
        /// <param name="projectTaskViewModel">Project Task view model</param>
        /// <returns>Http status</returns>
        [Route("api/ProjectTask/Update")]
        [HttpPut]
        public async Task<IHttpActionResult> Update(ProjectTaskView projectTaskViewModel)
        {
            _projectTaskService.ValidateModel(_mapper.Map<IProjectTask>(projectTaskViewModel), ModelState.AddModelError);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _projectTaskService.UpdateAsync(_mapper.Map<IProjectTask>(projectTaskViewModel));
            return Ok();
        }
    }
}