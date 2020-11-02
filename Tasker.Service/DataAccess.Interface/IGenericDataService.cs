using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Service.Common;
using Tasker.Service.DataAccess.Interface;

namespace Tasker.Service.DataAccess.Interface
{
    public interface IGenericDataService<T> where T : Entity
    {
        Task<int> Create<TEntity>(T entity) where TEntity : Entity;
        Task<int> Delete(int id);
        Task<T> Get(int id);
        Task<T> Update<TEntity>(T entity) where TEntity : Entity;
        Task<IEnumerable<T>> GetAll();
    }
}
