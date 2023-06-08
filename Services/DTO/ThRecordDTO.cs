using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domen.Enums;

namespace Domen.Models
{
    public class ThRecordDTO
    {
       
        public long ID { get; set; }
     
        public long IdRecord { get; set; }
      
        public long IdMaterial { get; set; }
      
        public decimal Amount { get; set; }
        public decimal Quantity { get; set; }
    }
}