using System.ComponentModel.DataAnnotations;

namespace WebMvc.Models {
    public class CreateModel {
        public int Id { 
            get; 
            set; 
        }

        [StringLength(60, MinimumLength = 3)]
        public required string Title { 
            get; 
            set; 
        }

        [Display(Name = "Task Content")]
        public required string Content { 
            get; 
            set; 
        }

        [DataType(DataType.Date)]
        public DateTime DueDate { 
            get; 
            set; 
        }

        public static CreateModel NewTask(int numTasks) {
            var newTaskId = numTasks + 1;
            return new CreateModel {
                Id = newTaskId,
                Title = "",
                Content = "",
                DueDate = DateTime.Now
            };
        }
    }
}