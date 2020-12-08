using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaskManagmentSystem.Models
{
    public partial class TaskManagmentSystemContext : DbContext
    {
        public TaskManagmentSystemContext()
        {
        }

        public TaskManagmentSystemContext(DbContextOptions<TaskManagmentSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<TasksCategories> TasksCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ZEENAB;Database=TaskManagmentSystem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Categori__19093A0B549E53A2");

                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithOne(p => p.Categories)
                    .HasForeignKey<Categories>(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Categorie__Categ__3B75D760");
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PK__Tasks__7C6949B17716ED5E");

                entity.Property(e => e.CompletedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.DueDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Importance)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Subject)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TasksCategories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__TasksCat__0DE8C8CA0E4BD824");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TasksCategories)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TasksCate__TaskI__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
