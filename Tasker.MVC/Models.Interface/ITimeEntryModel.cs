using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker.MVC.Models.Interface
{
    public interface ITimeEntryModel
    {
        string Name { get; set; }
        DateTime TimeSpent { get; set; }
        string Description { get; set; }
    }
}
