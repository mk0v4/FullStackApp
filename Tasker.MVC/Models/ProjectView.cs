using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tasker.Common.Enums;
using Tasker.Common.Find;

namespace Tasker.WebAPI.Models
{
    public class ProjectView
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public DateTime? DueDate { get; set; }
        public PriorityLevel Priority { get; set; }
        public bool Completed { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }
        public ICollection<ProjectTaskView> Tasks { get; set; }

    }
}