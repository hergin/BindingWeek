using DomainModel;
namespace WebMvc.Service;

public interface ITaskService
{
    public List<MyTask> GetAllTasks();
    public MyTask? FindTaskById(int id);
    public void UpdateTaskById(int id, string title, string content, DateTime dueDate);
    public void CreateTask(int id, string title, string content, DateTime dueDate);
}