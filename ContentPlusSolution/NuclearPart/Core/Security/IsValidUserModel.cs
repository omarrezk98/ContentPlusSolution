namespace Core.Security
{
    public class IsValidUserModel
    {
        public IsValidUserModel()
        {
            IsValidUser = false;
        }
        public bool IsValidUser { get; set; }
        public object User { get; set; } = default!;
        public int ClientId { get; set; }
        public string UserId { get; set; } = default!;
        public int SiteId { get; set; }
    }
}
