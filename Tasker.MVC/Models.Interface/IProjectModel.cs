using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker.MVC.Models.Interface
{
    public interface IProjectModel
    {
        bool Completed { get; set; }
        string Description { get; set; }
        DateTime? DueDate { get; set; }
        string Name { get; set; }
        int Priority { get; set; }
        ICollection<ITaskModel> Tasks { get; set; }
    }
}
