using System;
using System.Collections.Generic;

namespace TaskManager.Models;

public partial class Project
{
    public int Id { get; set; }

    public string FullTitle { get; set; } = null!;

    public string? ShortTitle { get; set; }

    public string? Icon { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime? DeletedTime { get; set; }

    public DateTime? StartScheduledDate { get; set; }

    public DateTime? FinishScheduledDate { get; set; }

    public string? Description { get; set; }

    public int CreatorEmployeeId { get; set; }

    public int? ResponsibleEmployeeId { get; set; }

    public virtual Employee IdNavigation { get; set; } = null!;

    public virtual Employee? ResponsibleEmployee { get; set; }

    public virtual Task? Task { get; set; }
}
