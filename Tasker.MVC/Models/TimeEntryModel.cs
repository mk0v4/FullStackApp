using System;
using System.ComponentModel.DataAnnotations;
using Tasker.MVC.Models.Interface;

namespace Tasker.MVC.Models
{
    public class TimeEntryModel : ITimeEntryModel
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public TimeSpan TimeSpent { get; set; }
        public ProjectTaskModel ProjectTask { get; set; }
        public long ProjectTaskId { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }
    }
}