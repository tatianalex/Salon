using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domen.Models
{
    public class MaterialDTO
    {
       
        public long Id { get; set; }
        
        public string Name { get; set; } 
        public string Picture { get; set; } = string.Empty;
       
        public string Description { get; set; } = string.Empty;
        public long IdCategory { get; set; }
      
        public decimal Price { get; set; } 
        public decimal Ratio { get; set; } 
    }
}