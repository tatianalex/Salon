using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Domen.Models
{
    public class CalculationCard
    {
        [Required]
        public long IdService { get; set; }
        public Service Service { get; set; }
        public long IdMaterial { get; set; }
        public Material Material { get; set; } 
        public decimal Quantity { get; set; } 
    }
}