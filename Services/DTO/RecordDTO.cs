using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domen.Enums;

namespace Domen.Models
{
    public class RecordDTO
    {
        public long Id;

        
        public long ID { get; set; }
       
        public EnumRecordStatus Status { get; set; } = EnumRecordStatus.Active;
        public long IdChart { get; set; }
      
        public long IdService { get; set; }
      
        public decimal Amount { get; set; }
        public long IdUser { get; set; }
       
     
        public DateTime Start { get; set; } 
        public DateTime Finish { get; set; } 
     
    }
}