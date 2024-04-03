using Core.Enums;
using Core.Interface;

namespace Entity.SiteSection
{
	public class SiteConfiguration : BasicMangerTable, IUserOperationInterface, ISiteInterface
    {
        public int SiteConfigurationId { get; set; }
        public int SiteId { get; set; }
        public int Code { get; set; }
        public SiteConfigurationTypeEnum SiteConfigurationType { get; set; }
        public string Json { get; set; } = default!;

        public virtual Site Site { get; set; } = default!;
    }
}

