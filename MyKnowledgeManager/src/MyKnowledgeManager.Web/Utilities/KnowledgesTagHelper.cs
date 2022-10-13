using Ardalis.GuardClauses;
using MyKnowledgeManager.Core.Entities;
using MyKnowledgeManager.Web.Models;
using System.Text.RegularExpressions;

namespace MyKnowledgeManager.Web.Utilities
{
    public static class KnowledgesTagHelper
    {
        /// <summary>
        /// This function is used for converting a <see cref="KnowledgeTagJsonRecord"/> (of Tagify) to the <see cref="KnowledgeTag"/> object.
        /// </summary>
        /// <param name="knowledgeTagJsonRecords"></param>
        /// <returns></returns>
        public static List<KnowledgeTag> ConvertTagRecordsToDbObjects(List<KnowledgeTagJsonRecord> knowledgeTagJsonRecords)
        {
            Guard.Against.Null(knowledgeTagJsonRecords);

            List<KnowledgeTag> knowledgeTags = new();

            // Iterate over each item in the KnowledgeTagJsonRecord object and convert it to a KnowledgeTag object.
            for (int i = 0; i < knowledgeTagJsonRecords.Count; i++)
            {
                KnowledgeTag knowledgeTag = new(FinalizeTagString(knowledgeTagJsonRecords[i].Value));
                knowledgeTags.Add(knowledgeTag);
            }

            return knowledgeTags;
        }

        /// <summary>
        /// This function is used for checking a tag string and if have white space, removing it.
        /// </summary>
        /// <param name="tagString"></param>
        /// <returns></returns>
        public static string FinalizeTagString(string tagString)
        {
            tagString = tagString.Replace(" ", "_");

            Regex regex = new Regex("[*#$^&\"'()]");

            tagString = regex.Replace(tagString, string.Empty);

            return tagString.ToLower();
        }
    }
}
