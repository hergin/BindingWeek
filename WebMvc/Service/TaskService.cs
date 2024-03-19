using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;

namespace WebMvc.Service
{
    public class TaskService : ITaskService
    {
        public TaskService()
        {
            var taskDb = new TaskContext();
        }

        public List<MyTask> GetAllTasks()
        {
            var taskDb = new TaskContext();
            var tasks = taskDb.Tasks.Select(task => new MyTask(task.Id, task.Title, task.Content, task.DueDate))
                .ToList();

            return tasks;
        }

        public MyTask? FindTaskById(int id)
        {
            List<MyTask> tasks = GetAllTasks();
            return tasks.Find(task => task.Id == id);
        }

        public void UpdateTaskById(int id, string title, string content, DateTime dueDate)
        {
            var db = new TaskContext();
            List<MyTask> tasks = GetAllTasks();
            var existingTask = db.Tasks.SingleOrDefault(task => task.Id == id);

            if (existingTask != null)
            {
                existingTask.Title = title;
                existingTask.Content = content;
                existingTask.DueDate = dueDate;
                db.SaveChanges();
            }
            
            db.SaveChanges();
        }

        public void CreateTask(int id, string title, string content, DateTime dueDate)
        {
            var db = new TaskContext();
            db.Add(new TaskDataModel { Id = id, Title = title, Content = content, DueDate = dueDate });
            db.SaveChanges();
        }
    }
}