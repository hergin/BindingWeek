using Microsoft.EntityFrameworkCore;

namespace DomainModel
{
    public class MyTaskContext : DbContext
    {
        public DbSet<MyTask> Tasks { get; set; }
        public string DbPath { get; }

        public MyTaskContext()
        {
            DbPath = "tasks.db";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}