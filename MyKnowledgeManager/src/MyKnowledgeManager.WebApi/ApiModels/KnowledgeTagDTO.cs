namespace MyKnowledgeManager.WebApi.ApiModels
{
    /// <summary>
    /// This record is used as a DTO (Data Transfer Object) for <see cref="KnowledgeTag"/>
    /// </summary>
    public record KnowledgeTagDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string TagName { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

        public bool IsTrashItem { get; set; } = false;
    }
}
