namespace Friends.Common.Models
{
    public class AppSettings
    {
        public JwtSettings Jwt { get; set; } = new JwtSettings();
        public string SwaggerJsonUrl { get; set; } = string.Empty;
    }

    public class JwtSettings
    {
        public string SecurityKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public int ExpireDays { get; set; }
        public int ExpireDaysWithRemember { get; set; }
    }
}
