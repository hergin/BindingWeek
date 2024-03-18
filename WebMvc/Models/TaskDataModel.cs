using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

public class TaskDataModel
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public DateTime DueDate { get; set; }
    
}