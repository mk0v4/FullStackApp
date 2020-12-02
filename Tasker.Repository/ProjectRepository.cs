using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Tasker.DAL.Entities;
using Tasker.Model.Common;
using Tasker.Repository.Common;

namespace Tasker.Repository
{
    public class ProjectRepository : Repository, IProjectRepository
    {
        public ProjectRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<int> AddAsync(IProject entity)
        {
            return await base.AddAsync<ProjectEntity>(Mapper.Map<ProjectEntity>(entity));
        }
        public async Task<int> DeleteAsync(long id)
        {
            return await base.DeleteAsync<ProjectEntity>(id);
        }
        public async Task<int> DeleteAsync(IProject entity)
        {
            return await base.DeleteAsync<ProjectEntity>(Mapper.Map<ProjectEntity>(entity));
        }
        public async Task<int> UpdateAsync(IProject entity)
        {
            return await base.UpdateAsync<ProjectEntity>(Mapper.Map<ProjectEntity>(entity));
        }
        public async Task<IProject> Get(long id)
        {
            return Mapper.Map<IProject>(await base.Get<ProjectEntity>(id));
        }
        public async Task<IQueryable<IProject>> GetAll()
        {
            return Mapper.Map< IQueryable<IProject>>(await base.GetAll<ProjectEntity>());
        }
    }
}
