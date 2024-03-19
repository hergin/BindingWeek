using Microsoft.EntityFrameworkCore;
using DomainModel;
namespace Database;

public class DbConnection
{
    private MyTaskContext db;

    public DbConnection()
    {
        db = new MyTaskContext();
    }

    public void Save(MyTask newTask)
    {
        db.Add(newTask);
        db.SaveChanges();
    }

    public int Count() {
        return db.Tasks.Count();
    }

    public List<MyTask> GetAllTasks() {
        return db.Tasks.OrderBy(task => task.Id).ToList();
    }

    public MyTask ParseById(int id) {
        return db.Tasks.Single(task => task.Id == id);
    }

    public void UpdateById(int id, string title, string content, DateTime dueDate) {
        MyTask selectedTask = db.Tasks.Single(task => task.Id == id);
        selectedTask.Update(title, content, dueDate);
        db.SaveChanges();
    }
}
