using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker.MVC.Models.Interface
{
    public interface ITimeEntryModel
    {
        long Id { get; set; }
        string Name { get; set; }
        TimeSpan TimeSpent { get; set; }
        ProjectTaskModel ProjectTask { get; set; }
        long ProjectTaskId { get; set; }
        string Description { get; set; }
    }
}
