using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Tasker.Service.Common;
using Tasker.Service.DataAccess.Interface;

namespace Tasker.Service.DataAccess.Interface
{
    public interface IGenericDataService<T> where T : Entity
    {
        Task<int> Create<E>(T entity) where E : Entity;
        Task<int> Delete(long id);
        Task<T> Get(long id);
        Task<T> Update<E>(T entity) where E : Entity;
        IPagedList<T> Filter(IQueryable<T> source, string property, object value, int? pageNumber, int pageSize, string sortBy, string sortDirection);
    }
}
