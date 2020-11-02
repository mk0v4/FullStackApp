using System.Collections.Generic;
using System.Threading.Tasks;
using Tasker.Service.Models;

namespace Tasker.Service.Service.Interface
{
    public interface IProjectService
    {
        Task<int> Create(Project project);
        Task<IEnumerable<Project>> GetAll();
    }
}