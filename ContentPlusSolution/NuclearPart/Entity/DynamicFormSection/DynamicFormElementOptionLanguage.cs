using Core.Enums;
using Core.Interface;

namespace Entity.DynamicFormSection
{
    public class DynamicFormElementOptionLanguage : BasicAdminTable, IUserOperationInterface, ISiteInterface
    {
        public int DynamicFormElementOptionLanguageId { get; set; }
        public int DynamicFormElementOptionId { get; set; }
        public LanguageEnum LanguageId { get; set; }
        public string Value { get; set; } = default!;

        public virtual DynamicFormElementOption DynamicFormElementOption { get; set; } = default!;
    }
}
