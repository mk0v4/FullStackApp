using System;
using Tasker.Service.Enums;
using Tasker.Service.FilterModels.Interface;

namespace Tasker.Service.FilterModels
{
    public class ProjectTaskFilterParams : IProjectTaskFilterParams
    {
        public string Name { get; set; }
        public DateTime? DueDate { get; set; }
        public PriorityLevel? Priority { get; set; }
        public TimeSpan? EstimatedTime { get; set; }
        public bool? Completed { get; set; }
        public string Description { get; set; }
    }
}
