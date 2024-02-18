using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entity.MangerSection
{
    public class MangerRefreshToken
    {
        public MangerRefreshToken()
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
        public string MangerId { get; set; } = default!;
        [ForeignKey("MangerId")]
        public virtual Manger Manger { get; set; } = default!;
    }
}
