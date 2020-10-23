﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tasker.MVC.Models.Interface;

namespace Tasker.MVC.Models
{
    public class TaskModel : ITaskModel
    {
        public string Name { get; set; }
        public DateTime? DueDate { get; set; }
        public int Priority { get; set; }
        public DateTime? EstimatedTime { get; set; }
        public bool Completed { get; set; }
        public string Description { get; set; }
        public ICollection<ITimeEntryModel> TimeEntries { get; set; }
    }
}