using System.ComponentModel.DataAnnotations;

namespace WebMvc.Models
{
    public class TaskEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DueDate { get; set; }
    }
}
