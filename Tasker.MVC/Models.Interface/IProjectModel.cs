using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker.MVC.Models.Interface
{
    public interface IProjectModel
    {
        long Id { get; set; }
        bool Completed { get; set; }
        string Description { get; set; }
        [Display(Name = "Due Date")]
        DateTime? DueDate { get; set; }
        string Name { get; set; }
        int Priority { get; set; }
        ICollection<IProjectTaskModel> Tasks { get; set; }
    }
}
