using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using WebMvc.Models;
namespace WebMvc.Service
{
    public class TaskService
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
            return tasks;
        }
        public MyTask? FindTaskByID(int id)
        {
            return tasks.Find(t => t.Id == id);
        }
        public void UpdateTaskByID(int id, string title, string content, DateTime dueDate)
        {
            var existingTask = tasks.Find(t => t.Id == id);
            existingTask.Update(title, content, dueDate);
        }

        public void CreateTask(TaskEditModel model)
        {
            var newTask = new MyTask(tasks.Count + 1, model.Title, model.Content, model.DueDate);
            tasks.Add(newTask);
        }

    }
}
