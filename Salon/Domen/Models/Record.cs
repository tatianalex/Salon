using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domen.Enums;

namespace Domen.Models
{
    public class Record
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [Required] 
        public EnumRecordStatus Status { get; set; } = EnumRecordStatus.Active;
        public long IdChart { get; set; }
        public Chart Chart { get; set; }
        public long IdService { get; set; }
        public Service Service { get; set; }
        public decimal Amount { get; set; }
        public long IdUser { get; set; }
        public User User { get; set; }
        public  List <Record> Records { get; set; } 
    }
}