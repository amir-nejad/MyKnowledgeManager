using AutoMapper;
using MyKnowledgeManager.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyKnowledgeManager.WebApi.ApiModels
{
    /// <summary>
    /// This record is used as a DTO (Data Transfer Object) for <see cref="Knowledge"/>
    /// </summary>
    public record KnowledgeDTO
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
        public string[] KnowledgeTags { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

        public bool IsTrashItem { get; set; } = false;
    }
}
