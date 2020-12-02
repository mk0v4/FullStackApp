using System.Linq;
using PagedList;
using Tasker.Common.Find.Interface;

namespace Tasker.Common.Find
{
    public class Paging<T> : IPaging<T>
    {
        public IPagedList<T> PaginateData(IFindParams filterElements, IQueryable<T> data)
        {
            return data.ToPagedList(filterElements.PageNumber ?? 1, filterElements.NumberOfRows);
        }
    }
}
