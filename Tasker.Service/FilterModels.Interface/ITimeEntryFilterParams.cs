using System;

namespace Tasker.Service.FilterModels.Interface
{
    public interface ITimeEntryFilterParams
    {
        string Description { get; set; }
        string Name { get; set; }
        TimeSpan? TimeSpent { get; set; }
    }
}