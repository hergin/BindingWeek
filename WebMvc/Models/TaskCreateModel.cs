using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DomainModel;
namespace WebMvc.Models
{
    public class TaskCreateModel
    {
        public int Id {get; set; }

        [StringLength(50)]
        public string Title {get; set; }
        [StringLength(100)]
        [Display(Name = "Task Description ")]
        public string Content {get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate {get; set; }

        public static TaskCreateModel FromTask(MyTask task) 
        {
            return new TaskCreateModel
            {
                Id = task.Id,
                Title = task.Title,
                Content = task.Content,
                DueDate = task.DueDate
            };
        }
    }
}