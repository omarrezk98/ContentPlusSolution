using Core.Enums;
using Core.Interface;

namespace Entity.ContentSection
{
    public class ContentLanguage : BasicAdminTable, IUserOperationInterface, ISiteInterface
    {
        public int ContentLanguageId { get; set; }
        public int ContentId { get; set; }
        public LanguageEnum LanguageId { get; set; }
        public string Url { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Subtitle { get; set; } = default!;
        public string? Body { get; set; }
        public string? Image { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeywords { get; set; }

        public virtual Content Content { get; set; } = default!;
    }
}
