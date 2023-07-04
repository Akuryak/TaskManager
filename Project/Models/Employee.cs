using System;
using System.Collections.Generic;

namespace TaskManager.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronomic { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Project? ProjectIdNavigation { get; set; }

    public virtual ICollection<Project> ProjectResponsibleEmployees { get; set; } = new List<Project>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
