using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domen.Enums;

namespace Domen.Models
{
    public class ThRecord
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [Required]
        public long IdRecord { get; set; }
        public Record Record { get; set; }
        public long IdMaterial { get; set; }
        public Material Material { get; set; }
        public decimal Amount { get; set; }
        public decimal Quantity { get; set; }
    }
}