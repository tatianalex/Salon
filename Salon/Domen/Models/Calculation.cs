using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Domen.Models
{
    public class Calculation
    {
        [Required]
        public long IdService { get; set; }
        public Service Service { get; set; }
        public decimal Price { get; set; } 
    }
}