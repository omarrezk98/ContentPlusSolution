using Core.Interface;
using Entity.SiteSection;

namespace Entity.ContentSection
{
    public class Content : BasicAdminTable, IUserOperationInterface, ISiteInterface
    {
        public int ContentId { get; set; }
        public int SitePageId { get; set; }
        public int? ContentCategoryId { get; set; }
        public bool Publish { get; set; }
        public bool ShowOnHomePage { get; set; }
        public int DisplayOrder { get; set; }
        public string? Icon { get; set; }

        public virtual SitePage SitePage { get; set; } = default!;
        public virtual ContentCategory? ContentCategory { get; set; }
        public virtual ICollection<ContentLanguage> ContentLanguage { get; set; } = [];
    }
}

