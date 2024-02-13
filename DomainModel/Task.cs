namespace DomainModel;

public class Task
{
    public int Id { get; }
    public string Title { get; }
    public string Content { get; }
    public DateTime DueDate { get; }

    public Task(int id, string title, string content)
    {
        Id = id;
        Title = title;
        Content = content;
    }

    public Task(int id, string title, string content, DateTime dueDate) : this(id, title, content)
    {
        DueDate = dueDate;
    }
}
