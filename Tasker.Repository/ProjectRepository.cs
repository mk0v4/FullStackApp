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
    public class ProjectRepository : Repository, IProjectRepository
    {
        private protected readonly IMapper _mapper;
        public ProjectRepository(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            this._mapper = mapper;
        }

        public async Task<int> AddAsync(IProject entity)
        {
            return await base.AddAsync<ProjectEntity>(_mapper.Map<ProjectEntity>(entity));
        }
        public async Task<int> DeleteAsync(long id)
        {
            return await base.DeleteAsync<ProjectEntity>(id);
        }
        public async Task<int> DeleteAsync(IProject entity)
        {
            return await base.DeleteAsync<ProjectEntity>(_mapper.Map<ProjectEntity>(entity));
        }
        public async Task<int> UpdateAsync(IProject entity)
        {
            return await base.UpdateAsync<ProjectEntity>(_mapper.Map<ProjectEntity>(entity));
        }
        public async Task<IProject> GetAsync(long id)
        {
            return _mapper.Map<IProject>(await base.GetAsync<ProjectEntity>(id));
        }
        public IList<IProject> Find(IFindParams findParams)
        {
            IQueryable<ProjectEntity> projectsQueryable = base.Find<ProjectEntity>();
            projectsQueryable = new Filter<ProjectEntity>(new ProjectFilterParams()).FilterData(findParams, projectsQueryable);
            projectsQueryable = new Sort<ProjectEntity>().SortData(findParams, projectsQueryable);
            projectsQueryable = new Paging<ProjectEntity>().PaginateData(findParams, projectsQueryable);
          return _mapper.Map<IList<IProject>>(projectsQueryable.ToList());
        }
    }
}
