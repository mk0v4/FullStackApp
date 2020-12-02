using System;
using System.Threading.Tasks;
using System.Web.Http;
using Tasker.Model.Common;

namespace Tasker.WebAPI.Controllers.Interface
{
    public interface IProjectTaskController
    {
        Task<IHttpActionResult> Create(IProjectTask projectTaskModel);
        Task<IHttpActionResult> Delete(IProjectTask projectTaskModel);
        Task<IHttpActionResult> Update(IProjectTask projectTaskModel);
        Task<IHttpActionResult> Get(long id);
        Task<IHttpActionResult> Find();
    }
}
