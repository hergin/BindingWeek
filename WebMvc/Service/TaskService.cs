using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using WebMvc.Models;

namespace WebMvc.Service
{
    public class TaskService : ITaskService
    {
        List<MyTask> tasks;
        public TaskService()
        {
            tasks = new List<MyTask>();
            tasks.Add(new MyTask(1, "420 Assignment", "Complete the 420 Create Task assignment", DateTime.Now.AddDays(3)));
            tasks.Add(new MyTask(2, "Spring Break", "Plan the spring break 24. Where to visit?", DateTime.Now.AddDays(10)));
        }
        public List<MyTask> GetAllTasks()
        {
            var db = new TaskDbContext();
            var MyTask = db.Contents.Select(b => new MyTask(
                b.Id,
                b.Title,
                b.Content,
                b.dueDate
            )).ToList();

            return tasks;
        }
        public MyTask? FindTaskByID(int id)
        {
            return tasks.Find(t => t.Id == id);
        }
        public void UpdateTaskByID(int id, string title, string content, DateTime dueDate)
        {
            List<MyTask> tasks = GetAllTasks();
            var db = new TaskDbContext();
            var existingTask = tasks.Find(t => t.Id == id);
            existingTask.Update(title, content, dueDate);
            
            var info = db.Contents.SingleOrDefault(t => t.Id == existingTask.Id);
            info.Title = title;
            info.Content = content;
            info.dueDate = dueDate;
            db.SaveChanges();
        }

        public void CreateTask (int id, string title, string content, DateTime dueDate) 
        {
            tasks.Add(new MyTask(id, title, content, dueDate));
            var db = new TaskDbContext();
            db.Add(new Infomation{Id = id, Title = title, Content = content, dueDate = DateTime.Now});
            db.SaveChanges();
        }

    }
}
