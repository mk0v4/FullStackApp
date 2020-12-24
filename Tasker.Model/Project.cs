using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PagedList;
using Tasker.Common.Enums;
using Tasker.Model.Common;

namespace Tasker.Model
{
    public class Project : IProject
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? DueDate { get; set; }
        public PriorityLevel Priority { get; set; }
        public bool Completed { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }
        public ICollection<IProjectTask> Tasks { get; set; }
    }
}
