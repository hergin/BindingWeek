using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class TaskContext : DbContext
{
    public DbSet<Task> Tasks {get; set;}
    public string DbPath {get;}
    public TaskContext(){
        DbPath = "task.db";
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
 => options.UseSqlite($"Data Source={DbPath}");
}

public class Task
{
    public int Id {get; set;}
    public string Title {get; set;}
    public string Content {get; set;}
    public DateTime DueDate {get; set;}
}