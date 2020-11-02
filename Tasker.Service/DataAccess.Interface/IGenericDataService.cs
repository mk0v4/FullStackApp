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
        Task<int> Create<E>(T entity) where E : Entity;
        Task<int> Delete(int id);
        Task<T> Get(int id);
        Task<T> Update<E>(T entity) where E : Entity;
        Task<IEnumerable<T>> GetAll();
    }
}
