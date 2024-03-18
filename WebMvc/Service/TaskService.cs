using System;
using System.Collections.Generic;
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
            // tasks = new List<MyTask>();
            var tasks = new TasksContext();

            tasks.Add(new TaskModel { Title = "420 Assignment", Content = "Complete the 420 Create Task assignment", DueDate = DateTime.Now.AddDays(3) });
            tasks.Add(new TaskModel { Title = "Spring Break", Content = "Plan the spring break 24. Where to visit?", DueDate = DateTime.Now.AddDays(10) });
        }
        public List<MyTask> GetAllTasks()
        {
            var tasksDb = new TasksContext();
            return [.. tasksDb.Tasks.Select(task => new MyTask(task.Id, task.Title, task.Content, task.DueDate))];
        }
        public MyTask? FindTaskByID(int id)
        {
            var allTasks = GetAllTasks();
            return allTasks.Find(tasks => tasks.Id == id);
        }
        public void UpdateTaskByID(int id, string title, string content, DateTime dueDate)
        {
            var tasksDb = new TasksContext();
            var tasks = GetAllTasks();
            var task = tasksDb.Tasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                task.Title = title;
                task.Content = content;
                task.DueDate = dueDate;
                tasksDb.SaveChanges();
            }
        }

        public void CreateTask(string title, string content, DateTime dueDate)
        {
            var tasksDb = new TasksContext();
            var tasks = GetAllTasks();
            tasksDb.Add(new TaskModel { Id = tasks.Count + 1, Title = title, Content = content, DueDate = dueDate });
            tasksDb.SaveChanges();
        }

    }
}
