using AutoMapper;
using MyKnowledgeManager.WebApi.ApiModels;

namespace MyKnowledgeManager.WebApi.MappingConfigurations
{
    public class KnowledgeProfile : Profile
    {
        public KnowledgeProfile()
        {
            CreateMap<Knowledge, KnowledgeDTO>()
                .ForMember(dest => dest.KnowledgeTags, opt => opt.MapFrom(src => src.KnowledgeTagRelations.Select(x => x.KnowledgeTag.TagName).ToArray()));

            CreateMap<KnowledgeDTO, Knowledge>()
                .ConstructUsing(x => new Knowledge(x.Title, x.Description, x.KnowledgeLevel, x.KnowledgeImportance));
        }
    }
}
