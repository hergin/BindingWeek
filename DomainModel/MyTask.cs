namespace DomainModel;

public class MyTask
{
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

    public void Update(string title, string content, DateTime dueDate)
    {
        Title = title;
        Content = content;
        DueDate = dueDate;
    }
}
