using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domen.Models
{
    public class Service
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; } 
        public string Picture { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long IdCategory { get; set; }
        public CategoryService Category { get; set; }
        public  List <CalculationCard> CalculationCards { get; set; } 
    }
}