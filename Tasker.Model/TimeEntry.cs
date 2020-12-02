using System;
using System.ComponentModel.DataAnnotations;
using Tasker.Model.Common;

namespace Tasker.Model
{
    public class TimeEntry : ITimeEntry
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public TimeSpan TimeSpent { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }
        public long ProjectTaskId { get; set; }
        public IProjectTask ProjectTask { get; set; }
    }
}
