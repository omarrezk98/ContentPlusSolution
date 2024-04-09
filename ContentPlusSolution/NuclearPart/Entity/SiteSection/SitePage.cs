using Core.Interface;
using Entity.ContentSection;

namespace Entity.SiteSection
{
	public class SitePage : BasicMangerTable, IUserOperationInterface, ISiteInterface
    {
		public int SitePageId { get; set; }
        public int SiteId { get; set; }
        public int Code { get; set; }
       

        public virtual Site Site { get; set; } = default!;
		public virtual ICollection<Content> Content { get; set; } = [];
        public virtual ICollection<SitePageLanguage> SitePageLanguage { get; set; } = [];
    }
}

