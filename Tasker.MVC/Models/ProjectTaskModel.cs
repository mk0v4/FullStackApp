using System;
using System.ComponentModel.DataAnnotations;
using PagedList;
using Tasker.MVC.Models.Interface;

namespace Tasker.MVC.Models
{
    public class ProjectTaskModel : IProjectTaskModel
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; }
        public int Priority { get; set; }
        [Display(Name = "Estimated Time")]
        public TimeSpan? EstimatedTime { get; set; }
        public bool Completed { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }
        public ProjectModel Project { get; set; }
        public long ProjectId { get; set; }
        public IPagedList<TimeEntryModel> TimeEntriesPaged { get; set; }
    }
}