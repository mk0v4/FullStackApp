using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Tasker.MVC.Models;

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
        //ICollection<TimeEntryModel> TimeEntries { get; set; }
        IPagedList<TimeEntryModel> TimeEntriesPaged { get; set; }
    }
}
