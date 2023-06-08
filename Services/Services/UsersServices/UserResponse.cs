using Domen.Enums;

namespace Services.Services.UsersServices;

public class UserResponse
{
    public string Token { get; set; } = string.Empty;
    public string Supername { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public EnumUserRole Role { get; set; }
    public long Id { get; set; }
}
