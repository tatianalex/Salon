using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domen.Enums;

namespace Domen.Models
{
    public class SchelduleDTO
    {
       // [Key] public EnumsWeek Role { get; set; } = EnumsWeek.Sunday;
       public DayOfWeek Day { get; set; } = DayOfWeek.Sunday;
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        

    }
}