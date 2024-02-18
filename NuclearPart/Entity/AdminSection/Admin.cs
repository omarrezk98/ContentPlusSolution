using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.AdminSection
{
    public class Admin : IdentityUser<string>
    {
        public Admin()
        {
            Id = Guid.NewGuid().ToString();

            #region AdminSection
            AdminRefreshToken = new HashSet<AdminRefreshToken>(); 
            #endregion
        }

        public string Name { get; set; } = default!;
        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        [Column(TypeName = "int")]
        public int GenderId { get; set; }
        public string? Note { get; set; }
        public string? Photo { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public int SiteId { get; set; }


        public virtual ICollection<AdminRefreshToken> AdminRefreshToken { get; set; }


    }
}
