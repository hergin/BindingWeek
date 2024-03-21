namespace DomainModel
{
    public class MyTask
    {
        private static int _idCounter = 0;
        public int Id { get; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime DueDate { get; private set; }

        public MyTask(int id, string title, string content)
        {
            Id = id; 
            Title = title;
            Content = content;
        }

        public MyTask(int id, string title, string content, DateTime dueDate) : this(id, title, content)
        {
            DueDate = dueDate;
        }

        public MyTask(string title, string content, DateTime dueDate)
        {
            Id = ++_idCounter;
            Title = title;
            Content = content;
            DueDate = dueDate;
        }

        public void Update(string title, string content, DateTime dueDate)
        {
            Title = title;
            Content = content;
            DueDate = dueDate;
        }
    }

    public class TaskManager
    {
        private readonly TaskRepository _taskRepository;

        public TaskManager(TaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void CreateTask(string title, string content, DateTime dueDate)
        {
            MyTask newTask = new MyTask(title, content, dueDate);
            _taskRepository.AddTask(newTask);
        }

        public class TaskRepository
        {
            private List<MyTask> _tasks;

            public TaskRepository()
            {
                _tasks = new List<MyTask>();
            }
            internal void AddTask(MyTask newTask)
            {
                _tasks.Add(newTask);
                Console.WriteLine("Task added successfully!");
            }
        }
    }

    public class CreateTaskModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DueDate { get; set; }
    }
}