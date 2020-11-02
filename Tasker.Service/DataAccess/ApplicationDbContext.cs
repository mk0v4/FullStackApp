using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tasker.Service.Common;
using Tasker.Service.DataAccess.Interface;
using Tasker.Service.Models;

namespace Tasker.Service.DataAccess
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public new DbSet<T> Set<T>() where T : Entity
        {
            return base.Set<T>();
        }
        //public ApplicationDbContext() : base("TaskerDB") { }
        public ApplicationDbContext() : base() { }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }
        public DbSet<TimeEntry> TimeEntries { get; set; }
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
