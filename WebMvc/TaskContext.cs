using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WebMvc.Models;
public class TasksContext : DbContext
{
    public DbSet<TaskModel> Tasks { get; set; }

    public string DbPath { get; }
    public TasksContext()
    {
        DbPath = "tasks.db";
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite($"Data Source={DbPath}");

    public static implicit operator List<object>(TasksContext v)
    {
        throw new NotImplementedException();
    }
}