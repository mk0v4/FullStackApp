using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Tasker.MVC.Models.Interface
{
    public interface IProjectModel
    {
        long Id { get; set; }
        bool Completed { get; set; }
        string Description { get; set; }
        DateTime? DueDate { get; set; }
        string Name { get; set; }
        int Priority { get; set; }
        //ICollection<ProjectTaskModel> Tasks { get; set; }
        IPagedList<ProjectTaskModel> TasksPaged { get; set; }
    }
}
