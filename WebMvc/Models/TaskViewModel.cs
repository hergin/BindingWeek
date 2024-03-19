using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using DomainModel;

namespace WebMvc.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [Display(Name = "Task Content")]
        public string? Content { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        public static TaskViewModel FromTask(MyTask task)
        {
            return new TaskViewModel
            {
                Id = task.Id,
                Title = task.Title,
                Content = task.Content,
                DueDate = task.DueDate
            };
        }
    }
}