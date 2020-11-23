using System;
using Tasker.Service.Enums;

namespace Tasker.Service.FilterModels.Interface
{
    public interface IProjectFilterParams
    {
        bool Completed { get; set; }
        string Description { get; set; }
        DateTime? DueDate { get; set; }
        string Name { get; set; }
        PriorityLevel Priority { get; set; }
    }
}