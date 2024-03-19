using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using DomainModel;

namespace WebMvc.Service
{
    public class TaskService : ITaskService
    {
        DbConnection database;
        public TaskService()
        {
            database = new DbConnection();
            if(database.Count() <= 0) {
                database.Save(new MyTask(1, "420 Assignment", "Complete the 420 Create Task assignment", DateTime.Now.AddDays(3)));
                database.Save(new MyTask(2, "Spring Break", "Plan the spring break 24. Where to visit?", DateTime.Now.AddDays(10)));
            }
        }

        public List<MyTask> GetAllTasks()
        {
            return database.GetAllTasks();
        }

        public int getNextId() {
            return database.Count() + 1;
        }

        public void createTask(int id, string title, string content, DateTime dueDate) {
            database.Save(new MyTask(id, title, content, dueDate));
        }

        public MyTask? FindTaskByID(int id)
        {
            return database.ParseById(id);
        }

        public void UpdateTaskByID(int id, string title, string content, DateTime dueDate)
        {
            database.UpdateById(id, title, content, dueDate);
        }
    }
}
