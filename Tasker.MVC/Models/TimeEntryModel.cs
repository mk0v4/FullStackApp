using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tasker.MVC.Models.Interface;

namespace Tasker.MVC.Interface
{
    public class TimeEntryModel : ITimeEntryModel
    {
        public string Name { get; set; }
        public DateTime TimeSpent { get; set; }
        public string Description { get; set; }
    }
}