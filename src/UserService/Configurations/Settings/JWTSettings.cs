namespace UserService.Configurations.Settings
{
    public class JWTSettings
    {
        public string SecurityKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Lifetime { get; set; }
    }
}
