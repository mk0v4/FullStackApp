using System.Linq;
using PagedList;

namespace Tasker.Service.DataAccess.Interface
{
    public interface IPaging<T>
    {
        IPagedList<T> PaginateData(IFindParams filterElements, IQueryable<T> data);
    }
}