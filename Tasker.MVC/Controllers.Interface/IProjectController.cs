using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Tasker.Model.Common;

namespace Tasker.WebAPI.Controllers.Interface
{
    public interface IProjectController
    {
        ActionResult Create();
        Task<ActionResult> CreateModel(IProject projectModel);
        Task<ActionResult> Delete(long id);
        Task<ActionResult> DeleteModel(long id);
        Task<ActionResult> Details(long id, string searchString, int? searchInt, DateTime? searchDate, bool? searchBool, TimeSpan? searchTime, string searchProperty, int? pageNumber, string sortBy, string sortDirection);
        Task<ActionResult> Index(string searchString, int? searchInt, DateTime? searchDate, bool? searchBool, string searchProperty, int? pageNumber, string sortBy, string sortDirection);
        Task<ActionResult> Update(long id);
        Task<ActionResult> UpdateModel(IProject projectModel);
    }
}
