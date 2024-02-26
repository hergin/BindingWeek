using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using DomainModel;

namespace WebMvc.Models
{
    public class TaskCreateModel
    {

        [Display(Name = "Task Content")]
        public string Title { get; set; }
        [Display(Name = "Task Content")]
        public string Content { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        public static TaskCreateModel FromTask(MyTask task)
        {
            return new TaskCreateModel
            {
                Title = task.Title,
                Content = task.Content,
                DueDate = task.DueDate
            };
        }
    }
}