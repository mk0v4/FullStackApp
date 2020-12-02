using System;
using Tasker.Common.Enums;

namespace Tasker.Model.Common.FilterModels
{
    public interface IProjectTaskFilterParams
    {
        bool? Completed { get; set; }
        string Description { get; set; }
        DateTime? DueDate { get; set; }
        TimeSpan? EstimatedTime { get; set; }
        string Name { get; set; }
        PriorityLevel? Priority { get; set; }
    }
}