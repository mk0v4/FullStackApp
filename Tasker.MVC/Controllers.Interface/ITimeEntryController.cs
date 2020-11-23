using System.Threading.Tasks;
using System.Web.Mvc;
using Tasker.MVC.Models;

namespace Tasker.MVC.Controllers.Interface
{
    public interface ITimeEntryController
    {
        ActionResult Create(long taskId);
        Task<ActionResult> CreateModel(TimeEntryModel timeEntryModelModel);
        Task<ActionResult> Delete(long id);
        Task<ActionResult> DeleteModel(TimeEntryModel timeEntryModel);
        Task<ActionResult> Details(long id);
        Task<ActionResult> Update(long id);
        Task<ActionResult> UpdateModel(TimeEntryModel timeEntryModel);
    }
}
