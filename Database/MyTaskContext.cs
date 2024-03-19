using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using DomainModel;
namespace Database;

public class MyTaskContext : DbContext
{
    public DbSet<MyTask> Tasks { get; set; }
    public string DbPath { get; }
    
    public MyTaskContext() {
        var mainDirectory = Path.GetFullPath("..");
        DbPath = @$"{mainDirectory}\Database\tasks.db";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
}
