using Core.Interface;

namespace Entity.DynamicFormSection
{
    public class DynamicForm : BasicAdminTable, IUserOperationInterface, ISiteInterface
    {
        public int DynamicFormId { get; set; }
        public bool IsActive { get; set; }
        public bool IsPublish { get; set; }
        public int DisplayOrder { get; set; }
        public bool ShowOnHomePage { get; set; }
        public bool ShowCountryKeyInMobile { get; set; }
        public int FirstNameOrder { get; set; }
        public bool FirstNameIsRequired { get; set; }
        public bool FirstNameIsHide { get; set; }
        public int MiddleNameOrder { get; set; }
        public bool MiddleNameIsRequired { get; set; }
        public bool MiddleNameIsHide { get; set; }
        public int LastNameOrder { get; set; }
        public bool LastNameIsRequired { get; set; }
        public bool LastNameIsHide { get; set; }
        public int MobileOrder { get; set; }
        public bool MobileIsRequired { get; set; }
        public bool MobileIsHide { get; set; }
        public int EmailOrder { get; set; }
        public bool EmailIsRequired { get; set; }
        public bool EmailIsHide { get; set; }
        public int GenderOrder { get; set; }
        public bool GenderIsRequired { get; set; }
        public bool GenderIsHide { get; set; }
        public int CountryOrder { get; set; }
        public bool CountryIsRequired { get; set; }
        public bool CountryIsHide { get; set; }
        public int CityOrder { get; set; }
        public bool CityIsRequired { get; set; }
        public bool CityIsHide { get; set; }
        public int PostionOrder { get; set; }
        public bool PostionIsRequired { get; set; }
        public bool PostionIsHide { get; set; }
        public int WorkingPlaceOrder { get; set; }
        public bool WorkingPlaceIsRequired { get; set; }
        public bool WorkingPlaceIsHide { get; set; }

        public virtual ICollection<DynamicFormLanguage> DynamicFormLanguage { get; set; } = [];
        public virtual ICollection<DynamicFormElement> DynamicFormElement { get; set; } = [];
        public virtual ICollection<DynamicFormData> DynamicFormData { get; set; } = [];
    }
}
