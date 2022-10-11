using MyKnowledgeManager.Core.Aggregates.Knowledge.Entities;
using MyKnowledgeManager.Core.Aggregates.Knowledge.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyKnowledgeManager.Web.Models
{
    public record KnowledgeRecord
    {
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
    }
}
