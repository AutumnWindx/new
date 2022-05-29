using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WpfApp1
{
    public partial class newContext : DbContext
    {
        public newContext()
        {
        }

        public newContext(DbContextOptions<newContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StatusTask> StatusTasks { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=new;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusTask>(entity =>
            {
                entity.ToTable("StatusTask");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.DateOfPublic)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_of_public");

                entity.Property(e => e.Desk).HasMaxLength(50);

                entity.Property(e => e.IdAccepted).HasColumnName("Id_accepted");

                entity.Property(e => e.IdCreator).HasColumnName("Id_creator");

                entity.Property(e => e.IdStatusTask).HasColumnName("Id_StatusTask");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.IdAcceptedNavigation)
                    .WithMany(p => p.TaskIdAcceptedNavigations)
                    .HasForeignKey(d => d.IdAccepted)
                    .HasConstraintName("FK_Task_User1");

                entity.HasOne(d => d.IdCreatorNavigation)
                    .WithMany(p => p.TaskIdCreatorNavigations)
                    .HasForeignKey(d => d.IdCreator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_User");

                entity.HasOne(d => d.IdStatusTaskNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.IdStatusTask)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_StatusTask");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("First_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("Last_name");

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.SecondName)
                    .HasMaxLength(50)
                    .HasColumnName("Second_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
