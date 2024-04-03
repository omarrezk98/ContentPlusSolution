using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.ContentSection
{
	public class ContentCategory
	{
        public int ContentCategoryId { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public string? URLAr { get; set; }
        public string? URLEn { get; set; }
        public string? Icon { get; set; }
        public string? ImageAr { get; set; }
        public string? ImageEn { get; set; }
        public int? ParentId { get; set; }
        public bool Publish { get; set; }
        public bool ShowOnHomePage { get; set; }
        public int DisplayOrder { get; set; }

        public virtual ICollection<Content> Content { get; set; } = [];
        [ForeignKey("ParentId")]
        public virtual ContentCategory Parent { get; set; } = default!;
        public virtual ICollection<ContentCategory> Children { get; set; } =[];
    }
}

