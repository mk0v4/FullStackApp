using System;

namespace Tasker.Model.Common
{
    public interface ITimeEntry
    {
        string Description { get; set; }
        long Id { get; set; }
        string Name { get; set; }
        IProjectTask ProjectTask { get; set; }
        long ProjectTaskId { get; set; }
        TimeSpan TimeSpent { get; set; }
    }
}