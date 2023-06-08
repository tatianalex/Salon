using Domen.Enums;

namespace Services.Models.User;

public class UserShortModel
{
    public long Id { get; set; }
    public string Supername { get; set; }
    public string Name { get; set; } 

    public string Phone { get; set; } 

    public string PasswordHash { get; set; }

    public string PasswordKey { get; set; } 
    public EnumUserRole Role { get; set; } 

    public EnumUserStatus Status { get; set; } 
}