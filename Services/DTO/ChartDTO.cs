using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domen.Models
{
    public class ChartDTO
    {
      
        public long ID { get; set; }
        
        public DateTime Date { get; set; } 
        public DateTime Start { get; set; } 
        public DateTime Finish { get; set; } 

    }
}