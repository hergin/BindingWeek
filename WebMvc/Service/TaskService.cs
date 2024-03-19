using DomainModel;
using WebMvc.Data;
using Microsoft.EntityFrameworkCore;

namespace WebMvc.Service
{
    public class TaskService : ITaskService
    {
        private readonly MyTaskContext _context;

        public TaskService(MyTaskContext context)
        {
            _context = context;
        }

        public void AddTask(MyTask newTask)
        {
            var taskModel = new MyTaskModel
            {
                
                Title = newTask.Title,
                Content = newTask.Content,
                DueDate = newTask.DueDate
            };
            _context.Tasks.Add(taskModel);
            _context.SaveChanges();
        }

        public List<MyTask> GetAllTasks()
        {
            // Convert data model list to domain model list
            return _context.Tasks
                           .AsNoTracking()
                           .Select(t => new MyTask(t.Id, t.Title!, t.Content!, t.DueDate))
                           .ToList();
        }

        public MyTask? FindTaskByID(int id)
        {
            var taskModel = _context.Tasks.Find(id);
            if (taskModel == null) return null;
            return new MyTask(taskModel.Id, taskModel.Title!, taskModel.Content!, taskModel.DueDate);
        }

        public void UpdateTaskByID(int id, string title, string content, DateTime dueDate)
        {
            var taskModel = _context.Tasks.Find(id);
            if (taskModel != null)
            {
                taskModel.Title = title;
                taskModel.Content = content;
                taskModel.DueDate = dueDate;
                _context.SaveChanges();
            }
        }

        public void DeleteTaskByID(int id)
        {
            var taskModel = _context.Tasks.Find(id);
            if (taskModel != null)
            {
                _context.Tasks.Remove(taskModel);
                _context.SaveChanges();
            }
        }
    }
}
