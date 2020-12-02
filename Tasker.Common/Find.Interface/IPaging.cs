using System.Linq;
using PagedList;

namespace Tasker.Common.Find.Interface
{
    public interface IPaging<T>
    {
        IPagedList<T> PaginateData(IFindParams filterElements, IQueryable<T> data);
    }
}