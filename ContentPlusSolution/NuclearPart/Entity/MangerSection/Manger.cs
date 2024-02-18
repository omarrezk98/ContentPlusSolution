using Core.Enums;
using Entity.SiteSection;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.MangerSection
{
    public class Manger : IdentityUser<string>
    {
        public Manger()
        {
            Id = Guid.NewGuid().ToString();

            #region SiteSection
            Site = new HashSet<Site>();
            Site1 = new HashSet<Site>();
            Site2 = new HashSet<Site>();
            #endregion
            #region MangerSection
            MangerRefreshToken = new HashSet<MangerRefreshToken>();
            #endregion
        }

        public string Name { get; set; } = default!;
        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        [Column(TypeName = "int")]
        public GenderEnum GenderId { get; set; }
        public string? Note { get; set; }
        public string? Photo { get; set; }
        public bool IsDeleted { get; set; }

        #region SiteSection
        public virtual ICollection<Site> Site { get; set; }
        public virtual ICollection<Site> Site1 { get; set; }
        public virtual ICollection<Site> Site2 { get; set; }
        #endregion

        #region MangerSection
        public virtual ICollection<MangerRefreshToken> MangerRefreshToken { get; set; }
        #endregion
    }
}
