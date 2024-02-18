using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModel.AdminSection
{
    public class AdminViewModel
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
