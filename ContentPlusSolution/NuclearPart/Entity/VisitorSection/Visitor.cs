using Core.Enums;
using Entity.SiteSection;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.VisitorSection
{
    public class Visitor : IdentityUser<string>
    {
        public Visitor()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; } = default!;
        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        [Column(TypeName = "int")]
        public GenderEnum GenderId { get; set; }
        public string? Note { get; set; }
        public string? Photo { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public int SiteId { get; set; }

        public virtual Site Site { get; set; } = default!;
        public virtual ICollection<VisitorRefreshToken> VisitorRefreshToken { get; set; } = [];
    }
}
