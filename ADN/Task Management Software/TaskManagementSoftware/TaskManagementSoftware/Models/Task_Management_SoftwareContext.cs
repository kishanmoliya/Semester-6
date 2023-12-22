using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TaskManagementSoftware.Areas.User_Registration.Models;

namespace TaskManagementSoftware.Models
{
    public partial class Task_Management_SoftwareContext : DbContext
    {
        public Task_Management_SoftwareContext()
        {
        }

        public Task_Management_SoftwareContext(DbContextOptions<Task_Management_SoftwareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProjectList> ProjectList { get; set; } = null!;
        public virtual DbSet<UserRegistration> UserRegistrations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectList>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.ToTable("Project_List");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.DeadLine).HasColumnType("datetime");

                entity.Property(e => e.ProjectDescription).HasMaxLength(500);

                entity.Property(e => e.ProjectOwnerName).HasMaxLength(50);

                entity.Property(e => e.ProjectStartDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectTitle).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProjectLists)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_List_User_Registration");
            });

            modelBuilder.Entity<UserRegistration>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("User_Registration");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<TaskManagementSoftware.Areas.User_Registration.Models.Person>? Person { get; set; }
    }
}
