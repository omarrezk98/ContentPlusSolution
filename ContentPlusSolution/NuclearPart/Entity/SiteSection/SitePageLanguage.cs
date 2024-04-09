using Core.Interface;

namespace Entity.SiteSection
{
    public class SitePageLanguage : BasicMangerTable, IUserOperationInterface, ISiteInterface
    {
        public int SitePageLanguageId { get; set; }
        public int SiteId { get; set; }
        public int Code { get; set; }
        public string Url { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string? Subtitle { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeywords { get; set; }

        public virtual Site Site { get; set; } = default!;
    }
}
