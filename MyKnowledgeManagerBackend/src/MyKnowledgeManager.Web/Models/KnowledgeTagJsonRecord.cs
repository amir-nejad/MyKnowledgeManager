using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyKnowledgeManager.Web.Models
{
    public record KnowledgeTagJsonRecord
    {
        [Required]
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
