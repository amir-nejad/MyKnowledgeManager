namespace MyKnowledgeManager.Core.Enums
{
    /// <summary>
    /// This enumeration is used for identifying importance of a knowledge.
    /// </summary>
    public enum KnowledgeImportance
    {
        Neutral,
        Important,
        [Display(Name = "Very Important")]
        VeryImportant
    }
}
