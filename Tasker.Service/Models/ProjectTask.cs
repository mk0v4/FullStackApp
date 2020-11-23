using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tasker.Service.Common;
using Tasker.Service.Enums;

namespace Tasker.Service.Models
{
    public class ProjectTask : Entity
    {
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
        public Project Project { get; set; }
        public virtual ICollection<TimeEntry> TimeEntries { get; set; }

    }
}
