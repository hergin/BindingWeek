using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using WebMvc.Models;
namespace WebMvc.Service
{
    public class TaskService : ITaskService
    {
        public TaskService()
        {
            var db = new TaskContext();
            db.Add(new TaskDataModel{Title="Joe", Content="Momma", DueDate = DateTime.Now.AddDays(3)});
            db.Add(new TaskDataModel{Title="Eat", Content="My Shorts", DueDate = DateTime.Now.AddDays(10)});
        }
        public List<MyTask> GetAllTasks()
        {
            var db = new TaskContext();
            return db.Tasks.Select(t
                => new MyTask(t.Id, t.Title, t.Content, t.DueDate)).ToList();
        }
        public MyTask? FindTaskByID(int id)
        {
            return this.GetAllTasks().Find(t => t.Id == id);
        }
        public void UpdateTaskByID(int id, string title, string content, DateTime dueDate)
        {
            var db = new TaskContext(); 

            List<MyTask> tasks = this.GetAllTasks();

            var existingTask = tasks.Find(t => t.Id == id);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            existingTask.Update(title, content, dueDate);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            var task = db.Tasks.SingleOrDefault(t => t.Id == existingTask.Id);

            if(task!=null)
            {
                task.Title = title;
                task.Content = content;
                task.DueDate = dueDate;
                db.SaveChanges();
            }
        }

        public int GetNumTasks()
        {
            return this.GetAllTasks().Count();
        }

        public void CreateNewTask(int id, string title, string content, DateTime dueDate)
        {
            var db = new TaskContext();
            db.Add(new TaskDataModel{Id=id, Title=title, Content=content, DueDate=dueDate});
            db.SaveChanges();
        }

    }
}
