using System.Threading.Tasks;
using System.Web.Http;
using Tasker.Model.Common;

namespace Tasker.WebAPI.Controllers.Interface
{
    public interface ITimeEntryController
    {
        Task<IHttpActionResult> Create(ITimeEntry timeEntryModelModel);
        Task<IHttpActionResult> Delete(ITimeEntry timeEntryModel);
        Task<IHttpActionResult> Update(ITimeEntry timeEntryModel);
        Task<IHttpActionResult> Get(long id);
        Task<IHttpActionResult> Find();
    }
}
