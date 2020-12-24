using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PagedList;
using Tasker.Common.Enums;
using Tasker.Model.Common;

namespace Tasker.Model
{
    public class ProjectTask : IProjectTask
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? DueDate { get; set; }
        public PriorityLevel Priority { get; set; }
        public TimeSpan? EstimatedTime { get; set; }
        public bool Completed { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }
        public long ProjectId { get; set; }
        public IProject Project { get; set; }
        public ICollection<ITimeEntry> TimeEntries { get; set; }

    }
}
