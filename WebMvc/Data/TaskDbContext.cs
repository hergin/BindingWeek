
using Microsoft.EntityFrameworkCore;

namespace WebMvc.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }

        public DbSet<DataModel> Tasks { get; set; }
    }
}