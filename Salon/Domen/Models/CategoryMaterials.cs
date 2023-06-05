using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domen.Models
{
    public class CategoryMaterials
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } 
        public string Picture { get; set; } = string.Empty;
        [MaxLength(300)]
        public string Description { get; set; } = string.Empty; 
        public  List <Material> Materials { get; set; } 
    }
}