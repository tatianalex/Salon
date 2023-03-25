using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Domen.Models
{
    public class CatalogCategorii
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; } 
        public string Picture { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

    }
}