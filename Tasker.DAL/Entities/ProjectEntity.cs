using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tasker.Common.Enums;
using Tasker.DAL.Entities.Common;

namespace Tasker.DAL.Entities
{
    public class ProjectEntity : Entity
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public DateTime? DueDate { get; set; }
        public PriorityLevel Priority { get; set; }
        public bool Completed { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }
        public virtual ICollection<ProjectTaskEntity> Tasks { get; set; }
    }
}
