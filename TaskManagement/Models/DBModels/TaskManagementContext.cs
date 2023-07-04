using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Models.DBModels;

public partial class TaskManagementContext : DbContext
{
    public TaskManagementContext()
    {
    }

    public TaskManagementContext(DbContextOptions<TaskManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmpDesignation> EmpDesignations { get; set; }

    public virtual DbSet<EmpDetail> EmpDetails { get; set; }

    public virtual DbSet<TaskDetail> TaskDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-OFBGA6E;Database=TaskManagement;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmpDesignation>(entity =>
        {
            entity.HasKey(e => e.DesgId).HasName("PK__EmpDesig__553B1451CAAC00DB");

            entity.ToTable("EmpDesignation");

            entity.Property(e => e.DesgId).HasColumnName("Desg_Id");
            entity.Property(e => e.DesgName)
                .HasMaxLength(50)
                .HasColumnName("Desg_Name");
        });

        modelBuilder.Entity<EmpDetail>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__EmpDetai__AF2DBB9987A9A3DE");

            entity.Property(e => e.DesgId).HasColumnName("Desg_Id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("Middle_Name");

            entity.HasOne(d => d.Desg).WithMany(p => p.EmpDetails)
                .HasForeignKey(d => d.DesgId)
                .HasConstraintName("FK__EmpDetail__Desg___398D8EEE");
        });

        modelBuilder.Entity<TaskDetail>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__TaskDeta__7C6949B172EF53F2");

            entity.Property(e => e.AssignedDate).HasColumnType("date");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TaskDetails).HasMaxLength(50);
            entity.Property(e => e.TaskDuration).HasMaxLength(50);

            entity.HasOne(d => d.Emp).WithMany(p => p.TaskDetails)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK__TaskDetai__EmpId__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
