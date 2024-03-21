using System;
using System.Linq;

using var db = new TaskContext();

Console.WriteLine($"Database path: {db.DbPath}");

//Create
Console.WriteLine("Inserting new task");
db.Add(new Task{Id = 3, Title = "Data Persistence", Content = "Complete the 420 Assignment", DueDate = DateTime.Now.AddDays(15)});
db.SaveChanges();

//View
Console.WriteLine("Viewing all tasks");
var task = db.Tasks
.OrderBy(b => b.Id)
.First();

//Delete
Console.WriteLine("Deleting task");
db.Remove(task);
db.SaveChanges();