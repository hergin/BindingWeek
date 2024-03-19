using System.ComponentModel.DataAnnotations;

namespace WebMvc;

public class TaskDataModel
{
    [Key]
    public int Id { get; set; }
    
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime DueDate { get; set; }
}