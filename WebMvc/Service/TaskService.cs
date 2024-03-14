using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
namespace WebMvc.Service
{
    public class TaskService : ITaskService
    {
        public TaskService()
        {
            var db = new TaskContext();
            db.Add(new TaskDataModel{Title="420 Assignment", Content="Complete the 420 Create Task assignment", DueDate = DateTime.Now.AddDays(3)});
            db.Add(new TaskDataModel{Title="Spring Break", Content="Plan the spring break 24. Where to visit?", DueDate=DateTime.Now.AddDays(10)});
        }

        public List<MyTask> GetAllTasks()
        {
            var db = new TaskContext();
            var tasks = db.Tasks
                .Select(t => new MyTask(t.Id, t.Title, t.Content, t.DueDate)).ToList();
            return tasks;
        }

        public MyTask? FindTaskByID(int id)
        {
            List<MyTask> tasks = this.GetAllTasks();

            return tasks.Find(t => t.Id == id);
        }

        public void UpdateTaskByID(int id, string title, string content, DateTime dueDate)
        {
            var db = new TaskContext();

             List<MyTask> tasks = this.GetAllTasks();

            var existingTask = tasks.Find(t => t.Id == id);
            existingTask.Update(title, content, dueDate);

            var task = db.Tasks
                .SingleOrDefault(task => task.Id == existingTask.Id);
            
            if(task != null)
            {
                task.Title = title;
                task.Content = content;
                task.DueDate = dueDate;
                db.SaveChanges();
            }

        }

        public int GetAmountOfTasks()
        {
             List<MyTask> tasks = this.GetAllTasks();
            return tasks.Count();
        }

        public void CreateNewTask(int id, string title, string content, DateTime dueDate)
        {
            var db = new TaskContext();
            db.Add(new TaskDataModel{Id=id, Title=title, Content=content, DueDate=dueDate});
            db.SaveChanges();
        }
    }
}
