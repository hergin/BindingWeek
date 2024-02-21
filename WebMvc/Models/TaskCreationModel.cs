using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DomainModel;

namespace WebMvc.Models;

public class TaskCreationModel() {
    public int Id {get; set;}
    [StringLength(60, MinimumLength = 3)]
    public string Title { get; set; }
    [Display(Name = "Task Content")]
    public string Content { get; set; }
    [DataType(DataType.Date)]
    public DateTime DueDate { get; set; }

    public static TaskCreationModel createTask(int id)
    {
        return new TaskCreationModel
        {
            Id = id,
            Title = "New Task",
            Content = "Insert content here",
            DueDate = DateTime.Now,
        };
    }
}
