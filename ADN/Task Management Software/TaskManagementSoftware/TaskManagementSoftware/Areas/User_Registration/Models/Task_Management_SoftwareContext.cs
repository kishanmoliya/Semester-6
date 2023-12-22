using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaskManagementSoftware.Areas.User_Registration.Models
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

        public virtual DbSet<Person> Person { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Person");

                entity.Property(e => e.PersonAge).HasMaxLength(50);

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.PersonName).HasMaxLength(50);

                entity.Property(e => e.PersonStd).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
