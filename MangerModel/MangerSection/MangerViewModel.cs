namespace MangerModel.MangerSection
{
    public class MangerViewModel
    {
        public string Email { get; set; } = default!;
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Photo { get; set; } = default!;
        public string Note { get; set; } = default!;
        public bool PhoneNumberConfirmed { get; set; }
    }
}
