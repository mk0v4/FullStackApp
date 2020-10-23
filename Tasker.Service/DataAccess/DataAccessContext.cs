using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Tasker.Service.DataAccess.Interface;
using Tasker.Service.Models;

namespace Tasker.Service.DataAccess
{
    public class DataAccessContext : DbContext, IDbContext
    {
        public DataAccessContext() : base("TaskerDB") { }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TimeEntry> TimeEntries { get; set; }
    }
}
