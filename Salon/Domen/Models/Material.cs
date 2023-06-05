using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domen.Models
{
    public class Material
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } 
        public string Picture { get; set; } = string.Empty;
        [MaxLength(300)]
        public string Description { get; set; } = string.Empty;
        public long IdCategory { get; set; }
        public  CategoryMaterials Category { get; set; }
        public decimal Price { get; set; } 
        public decimal Ratio { get; set; } 
    }
}