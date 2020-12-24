using System.Linq;
using PagedList;
using Tasker.Common.Find.Interface;

namespace Tasker.Common.Find
{
    public class Paging<T> : IPaging<T>
    {
        public IQueryable<T> PaginateData(IFindParams filterElements, IQueryable<T> data)
        {
            return data.Skip(
                ((int) (filterElements.PageNumber == null ? 1 : filterElements.PageNumber) - 1) 
                * filterElements.NumberOfRows)
                .Take(filterElements.NumberOfRows);
        }
    }
}
