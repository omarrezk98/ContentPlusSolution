﻿using Core.Enums;
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
        public virtual ICollection<Site> Site { get; set; } = [];
        public virtual ICollection<Site> Site1 { get; set; } = [];
        public virtual ICollection<Site> Site2 { get; set; } = [];
        public virtual ICollection<SitePage> SitePage { get; set; } = [];
        public virtual ICollection<SitePage> SitePage1 { get; set; } = [];
        public virtual ICollection<SiteConfiguration> SiteConfiguration { get; set; } = [];
        public virtual ICollection<SiteConfiguration> SiteConfiguration1 { get; set; } = [];
        public virtual ICollection<SitePageLanguage> SitePageLanguage { get; set; } = [];
        public virtual ICollection<SitePageLanguage> SitePageLanguage1 { get; set; } = [];
        #endregion

        #region MangerSection
        public virtual ICollection<MangerRefreshToken> MangerRefreshToken { get; set; } = [];
        #endregion
    }
}
