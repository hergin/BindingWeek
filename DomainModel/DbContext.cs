using Microsoft.EntityFrameworkCore;

namespace DomainModel
{
    public class TaskContext : DbContext
    {
        public DbSet<MyTask> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\north\Documents\0_College\CS420\BindingWeekNorth\DomainModel\tasks.db");
        }
    }
}