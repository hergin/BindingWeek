namespace DomainModel;

public class MyTask
{
    public int Id { get; }
    public string Title { get; }
    public string Content { get; }
    public DateTime DueDate { get; }

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
}
