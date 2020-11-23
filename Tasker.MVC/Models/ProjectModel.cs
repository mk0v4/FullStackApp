using System;
using System.ComponentModel.DataAnnotations;
using PagedList;
using Tasker.MVC.Models.Interface;

namespace Tasker.MVC.Models
{
    public class ProjectModel : IProjectModel
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; }
        public int Priority { get; set; }
        public bool Completed { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }
        public IPagedList<ProjectTaskModel> TasksPaged { get; set; }
    }
}