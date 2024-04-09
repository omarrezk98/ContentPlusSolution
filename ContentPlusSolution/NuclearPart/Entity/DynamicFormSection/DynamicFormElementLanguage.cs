using Core.Enums;
using Core.Interface;

namespace Entity.DynamicFormSection
{
    public class DynamicFormElementLanguage : BasicAdminTable, IUserOperationInterface, ISiteInterface
    {
        public int DynamicFormElementLanguageId { get; set; }
        public int DynamicFormElementId { get; set; }
        public LanguageEnum LanguageId { get; set; }
        public string Label { get; set; } = default!;

        public virtual DynamicFormElement DynamicFormElement { get; set; } = default!;
    }
}
