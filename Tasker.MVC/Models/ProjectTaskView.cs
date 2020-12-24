using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tasker.Common.Enums;

namespace Tasker.WebAPI.Models
{
    public class ProjectTaskView
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public DateTime? DueDate { get; set; }
        public PriorityLevel Priority { get; set; }
        public TimeSpan? EstimatedTime { get; set; }
        public bool Completed { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }
        public long ProjectId { get; set; }
        public ProjectView Project { get; set; }
        public ICollection<TimeEntryView> TimeEntries { get; set; }
    }
}