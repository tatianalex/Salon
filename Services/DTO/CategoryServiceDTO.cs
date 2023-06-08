using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domen.Models
{
    public class CategoryServiceDTO
    {
       
        public long Id { get; set; }
      
        public string Name { get; set; } 
        public string Picture { get; set; } = string.Empty;
      
        public string Description { get; set; } = string.Empty;
      
    }
}