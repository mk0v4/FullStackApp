using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Tasker.MVC.Models;

namespace Tasker.MVC.Controllers.Interface
{
    public interface IProjectTaskController
    {
        ActionResult Create(long projectId);
        Task<ActionResult> CreateModel(ProjectTaskModel projectTaskModel);
        Task<ActionResult> Delete(long id);
        Task<ActionResult> DeleteModel(ProjectTaskModel projectTaskModel);
        Task<ActionResult> Details(long id, string searchString, TimeSpan? searchTime, string searchProperty, int? pageNumber, string sortBy, string sortDirection);
        Task<ActionResult> Update(long id);
        Task<ActionResult> UpdateModel(ProjectTaskModel projectTaskModel);
    }
}
