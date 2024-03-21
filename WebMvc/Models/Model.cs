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
    public int id {get; set;}
    public string title {get; set;}
    public string content {get; set;}
    public DateTime dueDate {get; set;}
}