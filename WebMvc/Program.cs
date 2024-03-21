using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using var db = new TaskContext();

Console.WriteLine($"Database path: {db.DbPath}");

//Create
Console.WriteLine("Inserting new task");
db.Add(new Task{id = 3, title = "Data Persistence", content = "Complete the 420 Assignment", dueDate = DateTime.Now.AddDays(15)});
db.SaveChanges();

//View
Console.WriteLine("Viewing all tasks");
var task = db.Tasks
.OrderBy(b => b.id)
.First();

//Delete
Console.WriteLine("Deleting task");
db.Remove(task);
db.SaveChanges();