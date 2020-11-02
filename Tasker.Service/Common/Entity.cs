using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker.Service.Common
{
    public abstract class Entity
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
