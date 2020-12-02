using System.Linq;

namespace Tasker.Common.Find.Interface
{
    public interface IFilter<T>
    {
        IQueryable<T> FilterData(IQueryable<T> data);
    }
}