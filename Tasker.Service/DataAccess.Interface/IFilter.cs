using System.Linq;

namespace Tasker.Service.DataAccess.Interface
{
    public interface IFilter<T>
    {
        IQueryable<T> FilterData(IQueryable<T> data);
    }
}