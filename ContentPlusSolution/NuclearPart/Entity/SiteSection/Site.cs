using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Entity.AdminSection;
using Entity.MangerSection;
using Entity.ContentSection;
using Entity.DynamicFormSection;

namespace Entity.SiteSection
{
    public class Site : BasicMangerTable
    {
        public int SiteId { get; set; }
        [StringLength(250)]
        public string Name { get; set; } = default!;
        public string? URL { get; set; }
        [StringLength(100)]
        public string Email { get; set; } = default!;
        [StringLength(100)]
        public string? Telephone { get; set; }
        [Column(TypeName = "date")]
        public DateTime ContractDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime RenewDate { get; set; }
        public string ContactName { get; set; } = default!;
        public string Mobile { get; set; } = default!;
        public bool IsActive { get; set; }
        public string? DeactivateId { get; set; }
        public DateTime? DeactivateDate { get; set; }

        [ForeignKey("DeactivateId")]
        public virtual Manger Deactivate { get; set; } = default!;
        
        #region AdminSection
        public virtual ICollection<Admin> Admin { get; set; } = [];
        #endregion
        #region SiteSection
        public virtual ICollection<SitePage> SitePage { get; set; } = [];
        public virtual ICollection<SiteLanguage> SiteLanguage { get; set; } = [];
        public virtual ICollection<SiteConfiguration> SiteConfiguration { get; set; } = [];
        public virtual ICollection<SitePageLanguage> SitePageLanguage { get; set; } = [];
        #endregion
        #region ContentSection
        public virtual ICollection<Content> Content { get; set; } = [];
        public virtual ICollection<ContentLanguage> ContentLanguage { get; set; } = [];
        public virtual ICollection<ContentCategory> ContentCategory { get; set; } = [];
        public virtual ICollection<ContentCategoryLanguage> ContentCategoryLanguage { get; set; } = [];
        #endregion
        #region DynamicFormSection
        public virtual ICollection<DynamicForm> DynamicForm { get; set; } = [];
        public virtual ICollection<DynamicFormData> DynamicFormData { get; set; } = [];
        public virtual ICollection<DynamicFormElement> DynamicFormElement { get; set; } = [];
        public virtual ICollection<DynamicFormElementData> DynamicFormElementData { get; set; } = [];
        public virtual ICollection<DynamicFormElementLanguage> DynamicFormElementLanguage { get; set; } = [];
        public virtual ICollection<DynamicFormElementOption> DynamicFormElementOption { get; set; } = [];
        public virtual ICollection<DynamicFormElementOptionLanguage> DynamicFormElementOptionLanguage { get; set; } = [];
        public virtual ICollection<DynamicFormLanguage> DynamicFormLanguage { get; set; } = [];
        #endregion
    }
}
