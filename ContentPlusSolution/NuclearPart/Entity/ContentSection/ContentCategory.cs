using Core.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.ContentSection
{
    public class ContentCategory : BasicAdminTable, IUserOperationInterface, ISiteInterface
    {
        public int ContentCategoryId { get; set; }
        public int? ParentId { get; set; }
        public bool Publish { get; set; }
        public bool ShowOnHomePage { get; set; }
        public int DisplayOrder { get; set; }
        public string? Icon { get; set; }

        public virtual ICollection<Content> Content { get; set; } = [];
        public virtual ICollection<ContentCategoryLanguage> ContentCategoryLanguage { get; set; } = [];
        [ForeignKey("ParentId")]
        public virtual ContentCategory Parent { get; set; } = default!;
        public virtual ICollection<ContentCategory> Children { get; set; } = [];
    }
}

