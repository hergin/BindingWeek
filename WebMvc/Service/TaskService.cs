using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
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
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            existingTask.Update(title, content, dueDate);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        public int GetNumTasks()
        {
            return tasks.Count();
        }

        public void CreateNewTask(int id, string title, string content, DateTime dueDate)
        {
            tasks.Add(new MyTask(id, title, content, dueDate));
        }

    }
}
