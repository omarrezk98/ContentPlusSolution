namespace MangerModel.MangerSection
{
    public class MangerRefreshTokenViewModel
    {
        public string Id { get; set; } = default!;
        public DateTime IssuedUtc { get; set; }
        public DateTime ExpiresUtc { get; set; }
        public string Token { get; set; } = default!;
        public string MangerId { get; set; } = default!;
    }
}
