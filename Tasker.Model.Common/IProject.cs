using System;
using System.Collections.Generic;
using PagedList;
using Tasker.Common.Enums;
using Tasker.Model;

namespace Tasker.Model.Common
{
    public interface IProject
    {
        bool Completed { get; set; }
        string Description { get; set; }
        DateTime? DueDate { get; set; }
        long Id { get; set; }
        string Name { get; set; }
        PriorityLevel Priority { get; set; }
        ICollection<IProjectTask> Tasks { get; set; }
        IPagedList<IProjectTask> TasksPaged { get; set; }
    }
}