using Core.Interface;

namespace Entity.DynamicFormSection
{
    public class DynamicFormElementOption : BasicAdminTable, IUserOperationInterface, ISiteInterface
    {
        public int DynamicFormElementOptionId { get; set; }
        public int DynamicFormElementId { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsPublish { get; set; }
        public virtual DynamicFormElement DynamicFormElement { get; set; } = default!;
        public virtual ICollection<DynamicFormElementData> DynamicFormElementData { get; set; } = [];
        public virtual ICollection<DynamicFormElementOptionLanguage> DynamicFormElementOptionLanguage { get; set; } = [];
    }
}
