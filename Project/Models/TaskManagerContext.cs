using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Models;

public partial class TaskManagerContext : DbContext
{
    public TaskManagerContext()
    {
    }

    public TaskManagerContext(DbContextOptions<TaskManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskStatus> TaskStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLazyLoadingProxies().UseMySql("server=localhost;database=Taskmanager;user=root;password=12345", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Login).HasMaxLength(15);
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.Password).HasMaxLength(15);
            entity.Property(e => e.Patronomic).HasMaxLength(45);
            entity.Property(e => e.Surname).HasMaxLength(45);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("project");

            entity.HasIndex(e => e.CreatorEmployeeId, "Creator_employee_idx");

            entity.HasIndex(e => e.ResponsibleEmployeeId, "Executive_employee_idx");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_time");
            entity.Property(e => e.CreatorEmployeeId).HasColumnName("Creator_employee_id");
            entity.Property(e => e.DeletedTime)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_time");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.FinishScheduledDate)
                .HasColumnType("datetime")
                .HasColumnName("Finish_scheduled_date");
            entity.Property(e => e.FullTitle)
                .HasColumnType("text")
                .HasColumnName("Full_title");
            entity.Property(e => e.Icon).HasColumnType("text");
            entity.Property(e => e.ResponsibleEmployeeId).HasColumnName("Responsible_employee_id");
            entity.Property(e => e.ShortTitle)
                .HasMaxLength(5)
                .HasColumnName("Short_title");
            entity.Property(e => e.StartScheduledDate)
                .HasColumnType("datetime")
                .HasColumnName("Start_scheduled_date");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ProjectIdNavigation)
                .HasForeignKey<Project>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Creator_employee");

            entity.HasOne(d => d.ResponsibleEmployee).WithMany(p => p.ProjectResponsibleEmployees)
                .HasForeignKey(d => d.ResponsibleEmployeeId)
                .HasConstraintName("Responsible_employee");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("task");

            entity.HasIndex(e => e.ExecutiveEmployeeId, "Employee_idx");

            entity.HasIndex(e => e.StatusId, "Status_idx");

            entity.HasIndex(e => e.PreviousTaskId, "Task_idx");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_time");
            entity.Property(e => e.Deadliine).HasColumnType("datetime");
            entity.Property(e => e.DeletedTime)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_time");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ExecutiveEmployeeId).HasColumnName("Executive_employee_id");
            entity.Property(e => e.FinishActualTime)
                .HasColumnType("datetime")
                .HasColumnName("Finish_actual_time");
            entity.Property(e => e.FullTitle)
                .HasColumnType("text")
                .HasColumnName("Full_title");
            entity.Property(e => e.PreviousTaskId).HasColumnName("Previous_task_id");
            entity.Property(e => e.ProjectId).HasColumnName("Project_id");
            entity.Property(e => e.ShortTitle)
                .HasMaxLength(15)
                .HasColumnName("Short_title");
            entity.Property(e => e.StartActualTime)
                .HasColumnType("datetime")
                .HasColumnName("Start_actual_time");
            entity.Property(e => e.StatusId)
                .HasDefaultValueSql("'1'")
                .HasColumnName("Status_id");
            entity.Property(e => e.UpdatedTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_time");

            entity.HasOne(d => d.ExecutiveEmployee).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ExecutiveEmployeeId)
                .HasConstraintName("Employee");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Task)
                .HasForeignKey<Task>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Project");

            entity.HasOne(d => d.PreviousTask).WithMany(p => p.InversePreviousTask)
                .HasForeignKey(d => d.PreviousTaskId)
                .HasConstraintName("Task");

            entity.HasOne(d => d.Status).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Status");
        });

        modelBuilder.Entity<TaskStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("task_status");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ColorHex)
                .HasMaxLength(15)
                .HasColumnName("Color_hex");
            entity.Property(e => e.Name).HasColumnType("text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
