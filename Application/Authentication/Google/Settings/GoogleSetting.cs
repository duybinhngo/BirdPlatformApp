namespace Application.Authentication.Google.Settings
{
    public class GoogleSetting
    {
        public const string GoogleSection = "Authentication:Google";
        public string ClientId { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
    }
}
