using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Tasker.WebAPI.Controllers.Interface
{
    /**
     CRUD methods
     */
    public interface IBaseController<T> where T : class
    {
        Task<IHttpActionResult> Get(long id);
        Task<IHttpActionResult> Find(long? id, int? pageNumber, string filterBy, string filter, string sortBy, string sortDirection);
        Task<IHttpActionResult> Create(T projectModel);
        Task<IHttpActionResult> Delete(long id);
        Task<IHttpActionResult> Update(T projectModel);
    }
}
