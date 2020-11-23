using System;
using PagedList;

namespace Tasker.MVC.Models.Interface
{
    public interface IProjectModel
    {
        long Id { get; set; }
        bool Completed { get; set; }
        string Description { get; set; }
        DateTime? DueDate { get; set; }
        string Name { get; set; }
        int Priority { get; set; }
        IPagedList<ProjectTaskModel> TasksPaged { get; set; }
    }
}
