using System.Threading.Tasks;
using Tasker.WebAPI.Controllers.Interface;
using Tasker.Service.Common;
using Tasker.Model.Common;
using System.Web.Http;
using Tasker.Common.Find.Interface;
using Tasker.Common.Find;
using AutoMapper;
using Tasker.WebAPI.Models;
using System;
using System.Collections.Generic;

namespace Tasker.WebAPI.Controllers
{
    /// <summary>
    /// Project information
    /// </summary>
    public class ProjectController : ApiController, IBaseController<ProjectView>
    {
        private protected readonly IProjectService _projectService;
        private protected readonly IMapper _mapper;

        private const int RowNumber = 4;

        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            this._projectService = projectService;
            this._mapper = mapper;
        }
        /// <summary>
        /// Gets Project by id
        /// </summary>
        /// <param name="id">Unique identifier for Project</param>
        /// <returns>Project</returns>
        [Route("api/Project/Get/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(long id)
        {
            return Ok(_mapper.Map<ProjectView>(await _projectService.Get(id)));
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
        /// <returns>List of Projects</returns>
        [Route("api/Project/Find")]
        [HttpGet]
        public async Task<IHttpActionResult> Find(long? id, int? pageNumber, string filterBy, string filterCondition, string sortBy, string sortDirection)
        {
            IFindParams fp = new FindParams(id, pageNumber, filterBy, filterCondition, RowNumber, sortBy, sortDirection);
            return Ok(_mapper.Map<IList<ProjectView>>(await _projectService.Find(fp)));
        }
        /// <summary>
        /// Creates new Project
        /// </summary>
        /// <param name="projectViewModel">Project view model</param>
        /// <returns>Http status</returns>
        [Route("api/Project/Create")]
        [HttpPost]
        public async Task<IHttpActionResult> Create(ProjectView projectViewModel)
        {
            _projectService.ValidateModel(_mapper.Map<IProject>(projectViewModel), ModelState.AddModelError);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _projectService.AddAsync(_mapper.Map<IProject>(projectViewModel));
            return Ok();

        }
        /// <summary>
        /// Deletes Project
        /// </summary>
        /// <param name="id">Unique identifier for Project</param>
        /// <returns>Http status</returns>
        [Route("api/Project/Delete/{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(long id)
        {
            try
            {
                _mapper.Map<IProject>(await _projectService.DeleteAsync(id));
            } 
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
        /// <summary>
        /// Updates Project
        /// </summary>
        /// <param name="projectViewModel">Project view model</param>
        /// <returns>Http status</returns>
        [Route("api/Project/Update")]
        [HttpPut]
        public async Task<IHttpActionResult> Update(ProjectView projectViewModel)
        {
            _projectService.ValidateModel(_mapper.Map<IProject>(projectViewModel), ModelState.AddModelError);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _projectService.UpdateAsync(_mapper.Map<IProject>(projectViewModel));
            return Ok();
        }
    }
}