using System.Linq;

namespace Tasker.Service.DataAccess.Interface
{
    public interface ISort<T>
    {
        IQueryable<T> SortData(FindParams filterElements, IQueryable<T> data);
    }
}