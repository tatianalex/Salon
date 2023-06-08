namespace Services.Services.UsersServices;

public class TokenResponse
    {
        public long UserId { get; set; }

        public string Supername { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;

    }
