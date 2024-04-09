using Core.Enums;
using Core.Interface;

namespace Entity.DynamicFormSection
{
    public class DynamicFormLanguage : BasicAdminTable, IUserOperationInterface, ISiteInterface
    {
        public int DynamicFormLanguageId { get; set; }
        public int DynamicFormId { get; set; }
        public LanguageEnum LanguageId { get; set; }
        public string Name { get; set; } = default!;
        public string? Subname { get; set; }
        public string? Description { get; set; }
        public string URL { get; set; } = default!;
        public string? Image { get; set; }
        public string? FirstNameLabel { get; set; }
        public string? MiddleNameLabel { get; set; }
        public string? LastNameLabel { get; set; }
        public string? MobileLabel { get; set; }
        public string? EmailLabel { get; set; }
        public string? GenderLabel { get; set; }
        public string? CountryLabel { get; set; }
        public string? CityLabel { get; set; }
        public string? PostionLabel { get; set; }
        public string? WorkingPlaceLabel { get; set; }

        public virtual DynamicForm DynamicForm { get; set; } = default!;
    }
}
