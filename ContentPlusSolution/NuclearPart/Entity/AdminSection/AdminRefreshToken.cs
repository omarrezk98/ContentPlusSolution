using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entity.AdminSection
{
    public class AdminRefreshToken
    {
        public AdminRefreshToken()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        [StringLength(450)]
        public string Id { get; set; }
        public DateTime IssuedUtc { get; set; }
        public DateTime ExpiresUtc { get; set; }
        [Required]
        [StringLength(450)]
        public string Token { get; set; } = default!;
        [StringLength(450)]
        public string AdminId { get; set; } = default!;
        [ForeignKey("AdminId")]
        public virtual Admin Admin { get; set; } = default!;
    }
}
