using DomainModel;

namespace WebMvc.Service;

public interface ITaskService
{
    List<MyTask> GetAllTasks();
    MyTask? FindTaskByID(int id);
    void UpdateTaskByID(int id, string title, string content, DateTime dueDate);
    void CreateTask(string title, string content, DateTime dueDate);
}