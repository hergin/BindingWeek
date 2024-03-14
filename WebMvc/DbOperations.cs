using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class TaskContext : DbContext
{
    public DbSet<TaskDataModel> Tasks {get; set;}
    public string DbPath {get;}

    public TaskContext()
    {
        DbPath = "tasks.db";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}