using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domen.Enums;



namespace Domen.Models
{
    public class User
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Supername { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
       
        [MaxLength(8)]
            public string Phone { get; set; }
        
        [Required]
        [MaxLength(10)]
        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordKey { get; set; } = string.Empty;
        public EnumUserRole Role { get; set; } = EnumUserRole.User;

        public EnumUserStatus Status { get; set; } = EnumUserStatus.New;
        public List<MailToken> Tokens { get; set; } = null!;
           
    }
}