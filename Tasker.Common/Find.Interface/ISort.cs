using System.Linq;

namespace Tasker.Common.Find.Interface
{
    public interface ISort<T>
    {
        IQueryable<T> SortData(IFindParams filterElements, IQueryable<T> data);
    }
}