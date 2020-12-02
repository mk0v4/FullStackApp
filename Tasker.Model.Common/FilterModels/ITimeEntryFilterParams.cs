using System;

namespace Tasker.Model.Common.FilterModels
{
    public interface ITimeEntryFilterParams
    {
        string Description { get; set; }
        string Name { get; set; }
        TimeSpan? TimeSpent { get; set; }
    }
}