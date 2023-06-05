using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Domen.Models
{
    public class Scheldule
    {
        [Key]
        public long DayOf { get; set; }
        [Required]
        [MaxLength(30)] 
        public string Name { get; set; } 
        public string Picture { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public  decimal  SessionDuration { get; set; } 

    }
}