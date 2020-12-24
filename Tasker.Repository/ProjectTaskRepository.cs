using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Tasker.Common.Find;
using Tasker.Common.Find.Interface;
using Tasker.DAL.Entities;
using Tasker.Model.Common;
using Tasker.Model.FilterModels;
using Tasker.Repository.Common;

namespace Tasker.Repository
{
    public class ProjectTaskRepository : Repository, IProjectTaskRepository
    {
        private protected readonly IMapper _mapper;
        public ProjectTaskRepository(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            this._mapper = mapper;
        }

        public async Task<int> AddAsync(IProjectTask entity)
        {
            return await base.AddAsync<ProjectTaskEntity>(_mapper.Map<ProjectTaskEntity>(entity));
        }
        public async Task<int> DeleteAsync(long id)
        {
            return await base.DeleteAsync<ProjectTaskEntity>(id);
        }
        public async Task<int> DeleteAsync(IProjectTask entity)
        {
            return await base.DeleteAsync<ProjectTaskEntity>(_mapper.Map<ProjectTaskEntity>(entity));
        }
        public async Task<int> UpdateAsync(IProjectTask entity)
        {
            return await base.UpdateAsync<ProjectTaskEntity>(_mapper.Map<ProjectTaskEntity>(entity));
        }
        public async Task<IProjectTask> GetAsync(long id)
        {
            return _mapper.Map<IProjectTask>(await base.GetAsync<ProjectTaskEntity>(id));
        }
        public IList<IProjectTask> Find(IFindParams findParams)
        {
            IQueryable<ProjectTaskEntity> projectTasksQueryable = base.Find<ProjectTaskEntity>();
            projectTasksQueryable = projectTasksQueryable.Where(pt => pt.ProjectId == findParams.Id);
            projectTasksQueryable = new Filter<ProjectTaskEntity>(new ProjectTaskFilterParams()).FilterData(findParams, projectTasksQueryable);
            projectTasksQueryable = new Sort<ProjectTaskEntity>().SortData(findParams, projectTasksQueryable);
            projectTasksQueryable = new Paging<ProjectTaskEntity>().PaginateData(findParams, projectTasksQueryable);
            return _mapper.Map<IList<IProjectTask>>(projectTasksQueryable.ToList());
        }
    }
}
