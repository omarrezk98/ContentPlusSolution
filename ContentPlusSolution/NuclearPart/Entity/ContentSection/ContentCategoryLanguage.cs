using Core.Enums;
using Core.Interface;

namespace Entity.ContentSection
{
    public class ContentCategoryLanguage : BasicAdminTable, IUserOperationInterface, ISiteInterface
    {
        public int ContentCategoryLanguageId { get; set; }
        public LanguageEnum LanguageId { get; set; }
        public int ContentCategoryId { get; set; }
        public string Name { get; set; } = default!;
        public string URL { get; set; } = default!;
        public string? Image { get; set; }

        public virtual ContentCategory ContentCategory { get; set; } = default!;
    }
}
