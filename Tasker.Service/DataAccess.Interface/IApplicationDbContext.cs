﻿using System.Data.Entity;
using System.Threading.Tasks;
using Tasker.Service.Common;
using Tasker.Service.Models;

namespace Tasker.Service.DataAccess.Interface
{
    public interface IApplicationDbContext
    {
        DbSet<T> Set<T>() where T : Entity;
        DbSet<Project> Projects { get; set; }
        DbSet<ProjectTask> Tasks { get; set; }
        DbSet<TimeEntry> TimeEntries { get; set; }
        Task<int> SaveChangesAsync();
    }
}
