using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel;
using Microsoft.VisualBasic;
using WebMvc.Database;
namespace WebMvc.Service
{
    public class TaskService : TaskServiceInterface
    {
        private readonly TaskDb _taskDb;

        public TaskService(TaskDb taskDb)
        {
            _taskDb = taskDb;
        }
        public List<MyTask> GetAllTasks()
        {

            var taskList = _taskDb.Task.Select(t => new MyTask(t.Id, t.Title, t.Content, t.DueDate)).ToList();
            return taskList;
        }
        public MyTask? FindTaskByID(int id)
        {
            var task = _taskDb.Task.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                return new MyTask(task.Id, task.Title, task.Content, task.DueDate);
            }
            return null;
        }
        public void UpdateTaskByID(int id, string title, string content, DateTime dueDate)
        {
            var task = _taskDb.Task.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.Title = title;
                task.Content = content;
                task.DueDate = dueDate;
                _taskDb.SaveChanges();

            }
        }

        public void CreateTask(string title, string content, DateTime duedate)
        {
            var newTask = new Database.Task
            {
                Title = title,
                Content = content,
                DueDate = duedate
            };
            _taskDb.Task.Add(newTask);
            _taskDb.SaveChanges();
        }

    }
}
