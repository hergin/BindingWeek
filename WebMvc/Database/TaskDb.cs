using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
namespace WebMvc.Database;

public class TaskDb : DbContext
{
    public TaskDb(DbContextOptions<TaskDb> options)
    : base(options)
    { }
    public DbSet<Task> Task { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite($"Data Source=Tasks.db");
}
public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime DueDate { get; set; }
}