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

    public virtual Project IdNavigation { get; set; } = null!;

    public virtual ICollection<Task> InversePreviousTask { get; set; } = new List<Task>();

    public virtual Task? PreviousTask { get; set; }

    public virtual TaskStatus Status { get; set; } = null!;
}
