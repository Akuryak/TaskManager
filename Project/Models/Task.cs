using System;
using System.Collections.Generic;

namespace TaskManager.Models;

public partial class Task
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public string FullTitle { get; set; } = null!;

    public string? ShortTitle { get; set; }

    public string? Description { get; set; }

    public int? ExecutiveEmployeeId { get; set; }

    public int StatusId { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public DateTime? DeletedTime { get; set; }

    public DateTime? Deadliine { get; set; }

    public DateTime? StartActualTime { get; set; }

    public DateTime? FinishActualTime { get; set; }

    public int? PreviousTaskId { get; set; }

    public virtual Employee? ExecutiveEmployee { get; set; }

    public virtual Project IdNavigation { get; set; } = null!;

    public virtual ICollection<Task> InversePreviousTask { get; set; } = new List<Task>();

    public virtual Task? PreviousTask { get; set; }

    public virtual TaskStatus Status { get; set; } = null!;

    public Task()
    {
    }

    public Task(int id, int projectId, string fullTitle, string? shortTitle, string? description, int? executiveEmployeeId, int statusId, DateTime createdTime, DateTime? updatedTime, DateTime? deletedTime, DateTime? deadliine, DateTime? startActualTime, DateTime? finishActualTime, int? previousTaskId, Employee? executiveEmployee, Project idNavigation, ICollection<Task> inversePreviousTask, Task? previousTask, TaskStatus status)
    {
        Id = id;
        ProjectId = projectId;
        FullTitle = fullTitle;
        ShortTitle = shortTitle;
        Description = description;
        ExecutiveEmployeeId = executiveEmployeeId;
        StatusId = statusId;
        CreatedTime = createdTime;
        UpdatedTime = updatedTime;
        DeletedTime = deletedTime;
        Deadliine = deadliine;
        StartActualTime = startActualTime;
        FinishActualTime = finishActualTime;
        PreviousTaskId = previousTaskId;
        ExecutiveEmployee = executiveEmployee;
        IdNavigation = idNavigation;
        InversePreviousTask = inversePreviousTask;
        PreviousTask = previousTask;
        Status = status;
    }
}
