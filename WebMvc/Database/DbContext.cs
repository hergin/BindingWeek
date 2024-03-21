using Microsoft.EntityFrameworkCore;
using System;


namespace WebMvc.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskEntity> Tasks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=tasks.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the TaskEntity table
            modelBuilder.Entity<TaskEntity>()
                .ToTable("Tasks"); // Sets the table name

            modelBuilder.Entity<TaskEntity>()
                .HasKey(t => t.Id); // Sets the primary key

            modelBuilder.Entity<TaskEntity>()
                .Property(t => t.Title)
                .IsRequired(); // Makes the Title property required

            modelBuilder.Entity<TaskEntity>()
                .Property(t => t.DueDate)
                .HasColumnType("Date"); // Sets the DueDate column type to Date
        }
    }

    public class TaskEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DueDate { get; set; }
    }
}