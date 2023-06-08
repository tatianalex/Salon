using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domen.Enums;



namespace Domen.Models
{
    public class UserDTO
    {
       
        public long Id { get; set; }
       
        public string Supername { get; set; } = string.Empty;
       
        public string Name { get; set; } = string.Empty;
       
       
            public string Phone { get; set; }
        
        
        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordKey { get; set; } = string.Empty;
        public EnumUserRole Role { get; set; } = EnumUserRole.User;

        public EnumUserStatus Status { get; set; } = EnumUserStatus.New;
        
        public string MailToken { get; set; }
    }
}