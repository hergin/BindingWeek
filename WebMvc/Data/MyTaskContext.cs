using Microsoft.EntityFrameworkCore;

namespace WebMvc.Data
{
    public class MyTaskContext : DbContext
    {
        public MyTaskContext(DbContextOptions<MyTaskContext> options)
            : base(options)
        {
        }

        public DbSet<MyTaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyTaskModel>().ToTable("Task");
        }

    }
}

