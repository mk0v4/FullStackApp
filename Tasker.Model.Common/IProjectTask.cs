using System;
using System.Collections.Generic;
using PagedList;
using Tasker.Common.Enums;

namespace Tasker.Model.Common
{
    public interface IProjectTask
    {
        bool Completed { get; set; }
        string Description { get; set; }
        DateTime? DueDate { get; set; }
        TimeSpan? EstimatedTime { get; set; }
        long Id { get; set; }
        string Name { get; set; }
        PriorityLevel Priority { get; set; }
        IProject Project { get; set; }
        long ProjectId { get; set; }
        ICollection<ITimeEntry> TimeEntries { get; set; }
        IPagedList<ITimeEntry> TimeEntriesPaged { get; set; }
    }
}