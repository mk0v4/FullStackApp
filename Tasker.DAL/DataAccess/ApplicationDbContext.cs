using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Tasker.DAL.DataAccess.Interface;
using Tasker.DAL.Entities.Common;

namespace Tasker.DAL.DataAccess
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
        public ApplicationDbContext() : base("TaskerDB") { }
        public override Task<int> SaveChangesAsync()
        {
            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreationDate = DateTime.Now;
                }
            }
            return base.SaveChangesAsync();
        }
    }
}
