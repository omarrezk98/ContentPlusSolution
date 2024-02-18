using Entity.MangerSection;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class BasicMangerTable
    {
        public string CreatedId { get; set; } = default!;
        public DateTime CreatedDate { get; set; }
        public string? ModifiedId { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [ForeignKey("CreatedId")]
        public virtual Manger Created { get; set; } = default!;
        [ForeignKey("ModifiedId")]
        public virtual Manger? Modified { get; set; }
    }
}
