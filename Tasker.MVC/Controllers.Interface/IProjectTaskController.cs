using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Tasker.Model.Common;

namespace Tasker.WebAPI.Controllers.Interface
{
    public interface IProjectTaskController
    {
        ActionResult Create(long projectId);
        Task<ActionResult> CreateModel(IProjectTask projectTaskModel);
        Task<ActionResult> Delete(long id);
        Task<ActionResult> DeleteModel(IProjectTask projectTaskModel);
        Task<ActionResult> Details(long id, string searchString, TimeSpan? searchTime, string searchProperty, int? pageNumber, string sortBy, string sortDirection);
        Task<ActionResult> Update(long id);
        Task<ActionResult> UpdateModel(IProjectTask projectTaskModel);
    }
}
