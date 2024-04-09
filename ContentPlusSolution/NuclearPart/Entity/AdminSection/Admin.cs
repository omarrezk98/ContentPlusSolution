using Core.Enums;
using Entity.ContentSection;
using Entity.DynamicFormSection;
using Entity.SiteSection;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.AdminSection
{
    public class Admin : IdentityUser<string>
    {
        public Admin()
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
        public virtual ICollection<AdminRefreshToken> AdminRefreshToken { get; set; } = [];

        #region ContentSection
        public virtual ICollection<Content> Content { get; set; } = [];
        public virtual ICollection<Content> Content1 { get; set; } = [];
        public virtual ICollection<ContentLanguage> ContentLanguage { get; set; } = [];
        public virtual ICollection<ContentLanguage> ContentLanguage1 { get; set; } = [];
        public virtual ICollection<ContentCategory> ContentCategory { get; set; } = [];
        public virtual ICollection<ContentCategory> ContentCategory1 { get; set; } = [];
        public virtual ICollection<ContentCategoryLanguage> ContentCategoryLanguage { get; set; } = [];
        public virtual ICollection<ContentCategoryLanguage> ContentCategoryLanguage1 { get; set; } = [];
        #endregion

        #region DynamicFormSection
        public virtual ICollection<DynamicForm> DynamicForm { get; set; } = [];
        public virtual ICollection<DynamicForm> DynamicForm1 { get; set; } = [];
        public virtual ICollection<DynamicFormElement> DynamicFormElement { get; set; } = [];
        public virtual ICollection<DynamicFormElement> DynamicFormElement1 { get; set; } = [];
        public virtual ICollection<DynamicFormElementLanguage> DynamicFormElementLanguage { get; set; } = [];
        public virtual ICollection<DynamicFormElementLanguage> DynamicFormElementLanguage1 { get; set; } = [];
        public virtual ICollection<DynamicFormElementOption> DynamicFormElementOption { get; set; } = [];
        public virtual ICollection<DynamicFormElementOption> DynamicFormElementOption1 { get; set; } = [];
        public virtual ICollection<DynamicFormElementOptionLanguage> DynamicFormElementOptionLanguage { get; set; } = [];
        public virtual ICollection<DynamicFormElementOptionLanguage> DynamicFormElementOptionLanguage1 { get; set; } = [];
        public virtual ICollection<DynamicFormLanguage> DynamicFormLanguage { get; set; } = [];
        public virtual ICollection<DynamicFormLanguage> DynamicFormLanguage1 { get; set; } = [];
        #endregion
    }
}
