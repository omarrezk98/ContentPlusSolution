using Core.Enums;

namespace Entity.SiteSection
{
    public class SiteLanguage
    {
        public int SiteLanguageId { get; set; }
        public LanguageEnum LanguageId { get; set; }
        public int SiteId { get; set; }
        public virtual Site Site { get; set; } = default!;
    }
}
