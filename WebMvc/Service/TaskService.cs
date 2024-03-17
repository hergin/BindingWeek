using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel;
using WebMvc.Data;

namespace WebMvc.Service
{
    public class TaskService : ITaskService
    {
        private readonly TaskDbContext _dbContext;

        public TaskService(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<MyTask> GetAllTasks()
        {
            var tasks = _dbContext.Tasks.Select(t => new MyTask(t.Id, t.Title, t.Content, t.DueDate)).ToList();
            return tasks;
        }

        public MyTask? FindTaskByID(int id)
        {
            var taskDataModel = _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
            if (taskDataModel != null)
            {
                return new MyTask(taskDataModel.Id, taskDataModel.Title, taskDataModel.Content, taskDataModel.DueDate);
            }
            return null;
        }

        public void UpdateTaskByID(int id, string title, string content, DateTime dueDate)
        {
            var existingTask = _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
            if (existingTask != null)
            {
                existingTask.Title = title;
                existingTask.Content = content;
                existingTask.DueDate = dueDate;
                _dbContext.SaveChanges();
            }
        }

        public void CreateTask(string title, string content, DateTime dueDate)
        {
            var newTask = new DataModel
            {
                Title = title,
                Content = content,
                DueDate = dueDate
            };
            _dbContext.Tasks.Add(newTask);
            _dbContext.SaveChanges();
        }
    }
}