using System.ComponentModel.DataAnnotations;
using DomainModel;

namespace WebMvc.Models {
    public class TaskEditModel {
        public int Id { 
            get; 
            set; 
        }

        [StringLength(60, MinimumLength = 3)]
        public string? Title { 
            get; set; 
        
        }

        [Display(Name = "Task Content")]
        public string? Content { 
            get; 
            set; 
        }

        [DataType(DataType.Date)]
        public DateTime DueDate { 
            get; 
            set; 
        }

        public static TaskEditModel FromTask(MyTask task) {
            return new TaskEditModel {
                Id = task.Id,
                Title = task.Title,
                Content = task.Content,
                DueDate = task.DueDate
            };
        }
    }
}