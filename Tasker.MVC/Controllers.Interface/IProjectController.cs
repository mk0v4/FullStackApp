using System;
using System.Threading.Tasks;
using System.Web.Http;
using Tasker.Model.Common;

namespace Tasker.WebAPI.Controllers.Interface
{
    public interface IProjectController
    {
        Task<IHttpActionResult> Create(IProject projectModel);
        Task<IHttpActionResult> Delete(long id);
        Task<IHttpActionResult> Update(IProject projectModel);
        Task<IHttpActionResult> Get(long id);
        Task<IHttpActionResult> Find();
    }
}
