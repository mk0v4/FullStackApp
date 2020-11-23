using System;
using Tasker.Service.FilterModels.Interface;

namespace Tasker.Service.FilterModels
{
    public class TimeEntryFilterParams : ITimeEntryFilterParams
    {
        public string Name { get; set; }
        public TimeSpan TimeSpent { get; set; }
        public string Description { get; set; }
    }
}
