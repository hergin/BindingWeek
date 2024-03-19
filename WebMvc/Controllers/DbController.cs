using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class TaskContext : DbContext {
    public DbSet<TaskDataModel> Tasks {
        get;
        set;
    }

    public string DbPath {
        get;
    }

    public TaskContext() {
        DbPath = "tasks.db";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={DbPath}");
    
}
