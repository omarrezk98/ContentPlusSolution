using System.ComponentModel.DataAnnotations;

namespace Core.Security
{
    public class TokenRequest
    {
        [Required]
        public string Username { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;
    }
}
