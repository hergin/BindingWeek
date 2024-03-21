using DomainModel;
using System.Linq;

namespace WebMvc.Service
{
    public class TaskService : ITaskService
    {
        private readonly TaskContext _context;

        public TaskService(TaskContext context)
        {
            _context = context;
        }

        public List<MyTask> GetAllTasks()
        {
            return _context.Tasks.ToList();
        }

        public MyTask? FindTaskByID(int id)
        {
            return _context.Tasks.Find(id);
        }

        public void UpdateTaskByID(int id, string title, string content, DateTime dueDate)
        {
            var existingTask = _context.Tasks.Find(id);
            if (existingTask != null)
            {
                existingTask.Update(title, content, dueDate);
                _context.SaveChanges();
            }
        }

        public void AddTask(MyTask task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }
    }
}