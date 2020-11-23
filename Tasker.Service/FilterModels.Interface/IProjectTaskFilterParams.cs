using System;
using Tasker.Service.Enums;

namespace Tasker.Service.FilterModels.Interface
{
    public interface IProjectTaskFilterParams
    {
        bool Completed { get; set; }
        string Description { get; set; }
        DateTime? DueDate { get; set; }
        TimeSpan? EstimatedTime { get; set; }
        string Name { get; set; }
        PriorityLevel Priority { get; set; }
    }
}