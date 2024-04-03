using Core.Interface;
using Entity.ContentSection;

namespace Entity.SiteSection
{
	public class SitePage : BasicMangerTable, IUserOperationInterface, ISiteInterface
    {
		public int SitePageId { get; set; }
        public int SiteId { get; set; }
        public int Code { get; set; }
        public string? UrlAr { get; set; }
        public string? UrlEn { get; set; }
        public string? TitleAr { get; set; }
        public string? TitleEn { get; set; }
        public string? SubtitleAr { get; set; }
        public string? SubtitleEn { get; set; }
        public string? DescriptionAr { get; set; }
        public string? DescriptionEn { get; set; }
        public string? ImageAr { get; set; }
        public string? ImageEn { get; set; }
        public string? MetaTitleAr { get; set; }
        public string? MetaTitleEn { get; set; }
        public string? MetaDescriptionAr { get; set; }
        public string? MetaDescriptionEn { get; set; }
        public string? MetaKeywordsAr { get; set; }
        public string? MetaKeywordsEn { get; set; }

        public virtual Site Site { get; set; } = default!;
		public virtual ICollection<Content> Content { get; set; } = [];
    }
}

