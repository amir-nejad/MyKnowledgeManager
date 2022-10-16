using AutoMapper;
using MyKnowledgeManager.Web.Models;

namespace MyKnowledgeManager.Web.MappingConfigurations
{
    public class KnowledgeProfile : Profile
    {
        public KnowledgeProfile()
        {
            CreateMap<Knowledge, KnowledgeRecord>()
                .ForMember(dest => dest.KnowledgeTags, opt => opt.MapFrom(src => src.KnowledgeTagRelations.Select(x => x.KnowledgeTag).ToList()));

            CreateMap<KnowledgeRecord, Knowledge>()
                .ConstructUsing(x => new Knowledge(x.Title, x.Description, x.KnowledgeLevel, x.KnowledgeImportance));
        }
    }
}
