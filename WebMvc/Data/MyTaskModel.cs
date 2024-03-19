using System;
using System.ComponentModel.DataAnnotations;

namespace WebMvc.Data
{
    public class MyTaskModel
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime DueDate { get; set; }
    }
}
