using System;
using Tasker.Common.Enums;
using Tasker.Model.Common.FilterModels;

namespace Tasker.Model.FilterModels
{
    public class ProjectFilterParams : IProjectFilterParams
    {
        public string Name { get; set; }
        public DateTime? DueDate { get; set; }
        public PriorityLevel? Priority { get; set; }
        public bool? Completed { get; set; }
        public string Description { get; set; }
    }
}
