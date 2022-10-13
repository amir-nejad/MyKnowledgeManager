using AutoMapper;
using MyKnowledgeManager.Web.Models;

namespace MyKnowledgeManager.Web.MappingConfigurations
{
    public class KnowledgeProfile : Profile
    {
        public KnowledgeProfile()
        {
            CreateMap<Knowledge, KnowledgeRecord>();

            CreateMap<KnowledgeRecord, Knowledge>()
                .ConstructUsing(x => new Knowledge(x.Title, x.Description, x.KnowledgeLevel, x.KnowledgeImportance));
        }
    }
}
