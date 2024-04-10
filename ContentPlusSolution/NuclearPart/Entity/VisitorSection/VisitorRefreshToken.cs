using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entity.VisitorSection
{
    public class VisitorRefreshToken
    {
        public VisitorRefreshToken()
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
        public string VisitorId { get; set; } = default!;
        [ForeignKey("VisitorId")]
        public virtual Visitor Visitor { get; set; } = default!;
    }
}
