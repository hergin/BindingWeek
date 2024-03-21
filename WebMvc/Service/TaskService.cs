using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Data;
using DomainModel;
namespace WebMvc.Service
{
     public class TaskService
    {
        private readonly AppDbContext _dbContext;
        List<MyTask> tasks;
        public TaskService()
    {
        tasks = new List<MyTask>
        {
            new MyTask(1, "420 Assignment", "Complete the 420 Create Task assignment", DateTime.Now.AddDays(3)),
            new MyTask(2, "Spring Break", "Plan the spring break 2024. Where to visit?", DateTime.Now.AddDays(10)),
        };
        }

        public TaskService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
      public List<MyTask> GetAllTasks()
        {
            return _dbContext.Tasks
                .Select(te => new MyTask(te.Id, te.Title, te.Content, te.DueDate))
                .ToList();
        }
     public MyTask? FindTaskByID(int id)
        {
            var taskEntity = _dbContext.Tasks.Find(id);
            return taskEntity != null ? new MyTask(taskEntity.Id, taskEntity.Title, taskEntity.Content, taskEntity.DueDate) : null;
        }

     public void UpdateTaskByID(int id, string title, string content, DateTime dueDate)
        {
            var existingTask = _dbContext.Tasks.Find(id);
            if (existingTask != null)
            {
                existingTask.Title = title;
                existingTask.Content = content;
                existingTask.DueDate = dueDate;
                _dbContext.SaveChanges();
            }
        }

     public void AddsTask(MyTask newTask)
        {
            var taskEntity = new TaskEntity { Title = newTask.Title, Content = newTask.Content, DueDate = newTask.DueDate };
            _dbContext.Tasks.Add(taskEntity);
            _dbContext.SaveChanges();
            Console.WriteLine("Task added successfully!");
        }

        public void DeleteTaskById(int id)
{
    var taskToDelete = _dbContext.Tasks.Find(id);
    if (taskToDelete != null)
    {
        _dbContext.Tasks.Remove(taskToDelete);
        _dbContext.SaveChanges();
    }
}

}
}
