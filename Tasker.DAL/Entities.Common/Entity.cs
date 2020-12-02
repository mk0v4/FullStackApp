using System;

namespace Tasker.DAL.Entities.Common
{
    public abstract class Entity
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
