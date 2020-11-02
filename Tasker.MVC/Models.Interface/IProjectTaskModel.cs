using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker.MVC.Models.Interface
{
    public interface IProjectTaskModel
    {
        string Name { get; set; }
        DateTime? DueDate { get; set; }
        int Priority { get; set; }
        DateTime? EstimatedTime { get; set; }
        bool Completed { get; set; }
        string Description { get; set; }
        ICollection<ITimeEntryModel> TimeEntries { get; set; }
    }
}
