using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Tasker.MVC.Models;

namespace Tasker.MVC.Controllers.Interface
{
    public interface IProjectController
    {
        ActionResult Create();
        Task<ActionResult> CreateModel(ProjectModel projectModel);
        Task<ActionResult> Delete(long id);
        Task<ActionResult> DeleteModel(long id);
        Task<ActionResult> Details(long id, string searchString, int? searchInt, DateTime? searchDate, bool? searchBool, TimeSpan? searchTime, string searchProperty, int? pageNumber, string sortBy, string sortDirection);
        Task<ActionResult> Index(string searchString, int? searchInt, DateTime? searchDate, bool? searchBool, string searchProperty, int? pageNumber, string sortBy, string sortDirection);
        Task<ActionResult> Update(long id);
        Task<ActionResult> UpdateModel(ProjectModel projectModel);
    }
}
