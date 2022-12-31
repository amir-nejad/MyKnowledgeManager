using Ardalis.GuardClauses;
using MyKnowledgeManager.Core.Entities;
using MyKnowledgeManager.WebApi.ApiModels;
using System.Text.RegularExpressions;

namespace MyKnowledgeManager.WebApi.Utilities
{
    public static class KnowledgeTagHelper
    {
        /// <summary>
        /// This function is used for checking a tag string and if have white space, removing it.
        /// </summary>
        /// <param name="tagString"></param>
        /// <returns></returns>
        public static string FinalizeTagString(string tagString)
        {
            tagString = tagString.Replace(" ", "_");

            Regex regex = new Regex("[*#$@^&\"'()]");

            tagString = regex.Replace(tagString, string.Empty);

            return tagString.ToLower();
        }
    }
}
