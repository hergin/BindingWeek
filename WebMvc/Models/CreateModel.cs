using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DomainModel;
namespace WebMvc.Models
{
    public class CreateModel
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }
        [Display(Name = "Task Content")]
        public string Content { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        public static CreateModel NewTask(int amountOfTasks)
        {
            var newTaskId = amountOfTasks + 1;
            return new CreateModel
            {
                Id = newTaskId,
                Title = "",
                Content = "",
                DueDate = DateTime.Now
            };
        }
    }
}