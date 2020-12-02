using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Tasker.DAL.Entities;
using Tasker.Model.Common;
using Tasker.Repository.Common;

namespace Tasker.Repository
{
    public class ProjectTaskRepository : Repository, IProjectTaskRepository
    {
        public ProjectTaskRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<int> AddAsync(IProjectTask entity)
        {
            return await base.AddAsync<ProjectTaskEntity>(Mapper.Map<ProjectTaskEntity>(entity));
        }
        public async Task<int> DeleteAsync(long id)
        {
            return await base.DeleteAsync<ProjectTaskEntity>(id);
        }
        public async Task<int> DeleteAsync(IProjectTask entity)
        {
            return await base.DeleteAsync<ProjectTaskEntity>(Mapper.Map<ProjectTaskEntity>(entity));
        }
        public async Task<int> UpdateAsync(IProjectTask entity)
        {
            return await base.UpdateAsync<ProjectTaskEntity>(Mapper.Map<ProjectTaskEntity>(entity));
        }
        public async Task<IProjectTask> Get(long id)
        {
            return Mapper.Map<IProjectTask>(await base.Get<ProjectTaskEntity>(id));
        }
        public async Task<IQueryable<IProjectTask>> GetAll()
        {
            return Mapper.Map<IQueryable<IProjectTask>>(await base.GetAll<ProjectTaskEntity>());
        }
    }
}
