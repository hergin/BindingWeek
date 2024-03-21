using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebMvc.Models;

namespace WebMvc
{
    public class TaskDbContext : DbContext
    {
        public DbSet<Infomation> Contents { get; set;}
        public string DbPath { get; }

        public TaskDbContext()
        {
            DbPath = "tasks.db";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
    public class Infomation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime dueDate { get; set; }
    }
}
