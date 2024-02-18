namespace AdminModel.AdminSection
{
    public class AdminRefreshTokenViewModel
    {
        public string Id { get; set; } = default!;
        public DateTime IssuedUtc { get; set; }
        public DateTime ExpiresUtc { get; set; }
        public string Token { get; set; } = default!;
        public string AdminId { get; set; } = default!;
    }
}
