using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domen.Models
{
    public class Chart
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
         [Required]
        public DateTime Date { get; set; } 
        public DateTime Start { get; set; } 
        public DateTime Finish { get; set; } 

    }
}