using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entity.SiteSection
{
    public class Site : BasicMangerTable
    {
        public int SiteId { get; set; }
        [StringLength(250)]
        public string Name { get; set; } = default!;
        public string? URL { get; set; }
        [StringLength(100)]
        public string Email { get; set; } = default!;
        [StringLength(100)]
        public string? Telephone { get; set; }
        [Column(TypeName = "date")]
        public DateTime ContractDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime RenewDate { get; set; }
        public string ContactName { get; set; } = default!;
        public string Mobile { get; set; } = default!;
        public bool IsActive { get; set; }
    }
}
