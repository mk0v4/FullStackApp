using System;
using PagedList;

namespace Tasker.MVC.Models.Interface
{
    public interface IProjectTaskModel
    {
        long Id { get; set; }
        string Name { get; set; }
        DateTime? DueDate { get; set; }
        int Priority { get; set; }
        TimeSpan? EstimatedTime { get; set; }
        bool Completed { get; set; }
        string Description { get; set; }
        long ProjectId { get; set; }
        ProjectModel Project { get; set; }
        IPagedList<TimeEntryModel> TimeEntriesPaged { get; set; }
    }
}
