using System.Linq;
using PagedList;

namespace Tasker.Service.DataAccess.Interface
{
    public interface IPaging<T>
    {
        IPagedList<T> PaginateData(FindParams filterElements, IQueryable<T> data);
    }
}