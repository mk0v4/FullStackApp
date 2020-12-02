using System;
using Tasker.Model.Common.FilterModels;

namespace Tasker.Model.FilterModels
{
    public class TimeEntryFilterParams : ITimeEntryFilterParams
    {
        public string Name { get; set; }
        public TimeSpan? TimeSpent { get; set; }
        public string Description { get; set; }
    }
}
