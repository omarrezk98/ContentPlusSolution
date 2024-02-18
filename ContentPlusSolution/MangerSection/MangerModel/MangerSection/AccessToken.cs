namespace MangerModel.MangerSection
{
    public class AccessToken
    {
        public string? Token { get; set; }
        public MangerRefreshTokenViewModel? Refresh { get; set; }
        public DateTime Expiration { get; set; }
        public MangerViewModel? Profile { get; set; }
    }
}
