namespace MyKnowledgeManager.Core.Aggregates.Knowledge.Enums
{
    /// <summary>
    /// This enumeration is used for identifying importance of a knowledge.
    /// </summary>
    public enum KnowledgeImportance
    {
        [Display(Name = "Not Important")]
        NotImportant,
        Neutral,
        Important,
        [Display(Name = "Very Important")]
        VeryImportant
    }
}
