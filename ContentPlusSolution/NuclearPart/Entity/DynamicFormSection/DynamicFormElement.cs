using Core.Enums;
using Core.Interface;

namespace Entity.DynamicFormSection
{
    public class DynamicFormElement : BasicAdminTable, IUserOperationInterface, ISiteInterface
    {
        public int DynamicFormElementId { get; set; }
        public DynamicFormElementTypeEnum Type { get; set; }
        public int DynamicFormId { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsPublish { get; set; }
        public bool IsRequired { get; set; }

        public virtual DynamicForm DynamicForm { get; set; } = default!;
        public virtual ICollection<DynamicFormElementOption> DynamicFormElementOption { get; set; } = [];
        public virtual ICollection<DynamicFormElementData> DynamicFormElementData { get; set; } = [];
        public virtual ICollection<DynamicFormElementLanguage> DynamicFormElementLanguage { get; set; } = [];
    }
}
