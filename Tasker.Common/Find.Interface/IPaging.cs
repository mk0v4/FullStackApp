using System.Linq;
using PagedList;

namespace Tasker.Common.Find.Interface
{
    public interface IPaging<T>
    {
        IQueryable<T> PaginateData(IFindParams filterElements, IQueryable<T> data);
    }
}