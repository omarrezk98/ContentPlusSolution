using Entity.SiteSection;

namespace Entity.DynamicFormSection
{
    public class DynamicFormElementData
    {
        public int DynamicFormElementDataId { get; set; }
        public int SiteId { get; set; }
        public int DynamicFormDataId { get; set; }
        public int DynamicFormElementId { get; set; }
        public string? Value { get; set; }
        public int? DynamicFormElementOptionId { get; set; }
        public virtual Site Site { get; set; } = default!;
        public virtual DynamicFormData DynamicFormData { get; set; } = default!;
        public virtual DynamicFormElement DynamicFormElement { get; set; } = default!;  
        public virtual DynamicFormElementOption? DynamicFormElementOption { get; set; } 
    }
}
