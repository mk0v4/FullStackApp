using System.Linq;
using PagedList;
using Tasker.Service.DataAccess.Interface;

namespace Tasker.Service.DataAccess
{
    public class Paging<T> : IPaging<T>
    {
        public IPagedList<T> PaginateData(IFindParams filterElements, IQueryable<T> data)
        {
            return data.ToPagedList(filterElements.PageNumber ?? 1, filterElements.NumberOfRows);
        }
    }
}
