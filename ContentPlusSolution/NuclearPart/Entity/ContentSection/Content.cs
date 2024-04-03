using Core.Interface;
using Entity.SiteSection;

namespace Entity.ContentSection
{
	public class Content : BasicAdminTable, IUserOperationInterface, ISiteInterface
    {
		public int ContentId { get; set; }
		public int SitePageId { get; set; }
        public int? ContentCategoryId { get; set; }
        public string? UrlAr { get; set; }
        public string? UrlEn { get; set; }
        public string? TitleAr { get; set; }
        public string? TitleEn { get; set; }
        public string? SubtitleAr { get; set; }
        public string? SubtitleEn { get; set; }
        public string? BodyAr { get; set; }
        public string? BodyEn { get; set; }
        public string? ImageAr { get; set; }
        public string? ImageEn { get; set; }
        public string? MetaTitleAr { get; set; }
        public string? MetaTitleEn { get; set; }
        public string? MetaDescriptionAr { get; set; }
        public string? MetaDescriptionEn { get; set; }
        public string? MetaKeywordsAr { get; set; }
        public string? MetaKeywordsEn { get; set; }

        public virtual SitePage SitePage { get; set; } = default!;
        public virtual ContentCategory ContentCategory { get; set; } = default!;
    }
}

