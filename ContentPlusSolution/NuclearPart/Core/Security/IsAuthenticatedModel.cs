namespace Core.Security
{
    public class IsAuthenticatedModel
    {
        public IsAuthenticatedModel()
        {
            IsAuthenticated = false;
        }
        public bool IsAuthenticated { get; set; }
        public object AccessToken { get; set; } = default!;
        public IsValidUserModel IsValidUserModel { get; set; } = default!;
    }
}
