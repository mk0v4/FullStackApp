using System;

namespace Tasker.Service.Common
{
    public abstract class Entity
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
