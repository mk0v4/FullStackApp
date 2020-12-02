using System.Threading.Tasks;
using System.Web.Mvc;
using Tasker.Model;
using Tasker.Model.Common;

namespace Tasker.WebAPI.Controllers.Interface
{
    public interface ITimeEntryController
    {
        ActionResult Create(long taskId);
        Task<ActionResult> CreateModel(ITimeEntry timeEntryModelModel);
        Task<ActionResult> Delete(long id);
        Task<ActionResult> DeleteModel(ITimeEntry timeEntryModel);
        Task<ActionResult> Details(long id);
        Task<ActionResult> Update(long id);
        Task<ActionResult> UpdateModel(ITimeEntry timeEntryModel);
    }
}
