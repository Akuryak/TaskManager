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

    public int? CreatorEmployeeId { get; set; }

    public int? ResponsibleEmployeeId { get; set; }

    public virtual Task? Task { get; set; }

    public Project()
    {
    }

    public Project(int id, string fullTitle, string? shortTitle, string? icon, DateTime createdTime, DateTime? deletedTime, DateTime? startScheduledDate, DateTime? finishScheduledDate, string? description, int? creatorEmployeeId, int? responsibleEmployeeId, Task? task)
    {
        Id = id;
        FullTitle = fullTitle;
        ShortTitle = shortTitle;
        Icon = icon;
        CreatedTime = createdTime;
        DeletedTime = deletedTime;
        StartScheduledDate = startScheduledDate;
        FinishScheduledDate = finishScheduledDate;
        Description = description;
        CreatorEmployeeId = creatorEmployeeId;
        ResponsibleEmployeeId = responsibleEmployeeId;
        Task = task;
    }
}
