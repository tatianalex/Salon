using System.ComponentModel.DataAnnotations;

namespace Services.Services.UsersServices;

public class UserRequest
{
    /// <summary>
    /// Почта
    /// </summary>
    [Required]
    public string Phone { get; set; } = null!;

    /// <summary>
    /// Пароль
    /// </summary>
    [Required]
    public string Password { get; set; } = null!;
}
