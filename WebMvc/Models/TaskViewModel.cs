using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebMvc.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Display(Name = "Task Content")]
        public string Content { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
    }
}
