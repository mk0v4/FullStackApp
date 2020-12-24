using System;
using System.ComponentModel.DataAnnotations;

namespace Tasker.WebAPI.Models
{
    public class TimeEntryView
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public TimeSpan TimeSpent { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }
        public long ProjectTaskId { get; set; }
        public ProjectTaskView ProjectTask { get; set; }
    }
}