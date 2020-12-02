using System;
using System.ComponentModel.DataAnnotations;
using Tasker.DAL.Entities.Common;

namespace Tasker.DAL.Entities
{
    public class TimeEntryEntity : Entity
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public TimeSpan TimeSpent { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }
        public long ProjectTaskId { get; set; }
        public ProjectTaskEntity ProjectTask { get; set; }
    }
}
