using DomainModel;
namespace WebMvc.Service
{
    public class TaskService : ITaskService
    {
        private List<MyTask> tasks = new();
        public TaskService()
        {
            tasks = new List<MyTask>();
            {
                tasks.Add(new MyTask(1, "420 Assignment", "Complete the 420 Create Task assignment", DateTime.Now.AddDays(3)));
                tasks.Add(new MyTask(2, "Spring Break", "Plan the spring break 24. Where to visit?", DateTime.Now.AddDays(10)));
            };
        }
        public List<MyTask> GetAllTasks() => tasks;

        public MyTask? FindTaskByID(int id) => tasks.Find(t => t.Id == id);

        public void UpdateTaskByID(int id, string title, string content, DateTime dueDate)
        {
            var existingTask = FindTaskByID(id);
            if (existingTask != null)
            {
                existingTask.Update(title, content, dueDate);
            }
        }

        public void AddTask(MyTask newTask)
        {
            int newId = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1;
            var taskToAdd = new MyTask(newId, newTask.Title, newTask.Content, newTask.DueDate);
            tasks.Add(taskToAdd);
        }
    }
}
