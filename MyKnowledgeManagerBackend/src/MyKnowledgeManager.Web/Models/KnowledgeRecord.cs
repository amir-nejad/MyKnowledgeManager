using MyKnowledgeManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyKnowledgeManager.Web.Models
{
    public record KnowledgeRecord
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Title { get; set; }

        [Required]
        [MinLength(30)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Importance")]
        public KnowledgeImportance KnowledgeImportance { get; set; }

        [Display(Name = "Level")]
        public KnowledgeLevel KnowledgeLevel { get; set; }

        [Display(Name = "Tags")]
        public IEnumerable<KnowledgeTag> KnowledgeTags { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

        public bool IsTrashItem { get; set; } = false;
    }
}
