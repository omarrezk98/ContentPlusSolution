namespace AdminModel.AdminSection
{
    public class AccessToken
    {
        public string? Token { get; set; }
        public AdminRefreshTokenViewModel? Refresh { get; set; }
        public DateTime Expiration { get; set; }
        public AdminViewModel? Profile { get; set; }
    }
}
