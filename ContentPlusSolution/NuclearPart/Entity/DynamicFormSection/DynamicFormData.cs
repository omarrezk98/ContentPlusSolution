using Entity.SiteSection;

namespace Entity.DynamicFormSection
{
    public class DynamicFormData
    {
        public int DynamicFormDataId { get; set; }
        public string Code { get; set; } = default!;
        public int SiteId { get; set; }
        public int DynamicFormId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public int? Gender { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public string? CityName { get; set; }
        public string? Postion { get; set; }
        public string? WorkingPlace { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual DynamicForm DynamicForm { get; set; } = default!;
        public virtual Site Site { get; set; } = default!;
        public virtual ICollection<DynamicFormElementData> DynamicFormElementData { get; set; } = [];
    }
}
