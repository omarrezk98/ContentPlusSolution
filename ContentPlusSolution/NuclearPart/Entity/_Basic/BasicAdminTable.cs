using Entity.AdminSection;
using Entity.SiteSection;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
	public class BasicAdminTable
	{
        public int Code { get; set; }
        public int SiteId { get; set; }
        public string CreatedId { get; set; } = default!;
        public DateTime CreatedDate { get; set; }
        public string? ModifiedId { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Site Site { get; set; } = default!;
        [ForeignKey("CreatedId")]
        public virtual Admin Created { get; set; } = default!;
        [ForeignKey("ModifiedId")]
        public virtual Admin? Modified { get; set; }
    }
}

