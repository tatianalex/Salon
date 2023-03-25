using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domen.Enums;



namespace Domen.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Supername { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
       
        [MaxLength(8)]
            public string Phone { get; set; }
        
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordKey { get; set; } = string.Empty;
        public EnumUserRole Role { get; set; } = EnumUserRole.User;

        public EnumUserStatus Status { get; set; } = EnumUserStatus.New;
        public List<MailToken> Tokens { get; set; } = null!;
           
    }
}