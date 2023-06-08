using System.ComponentModel.DataAnnotations;

namespace Services.Services.UsersServices;

    public class RegisterRequest
    {
        [Required]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string ConfirmPassword { get; set; } = string.Empty;

        public string Supername { get; set; } = string.Empty;
        
        public string Name { get; set; } = string.Empty;

	
    }
