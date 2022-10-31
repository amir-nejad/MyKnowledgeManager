using AutoMapper;
using MyKnowledgeManager.Web.Models;

namespace MyKnowledgeManager.Web.MappingConfigurations
{
    public class KnowledgeTagProfile : Profile
    {
        public KnowledgeTagProfile()
        {
            CreateMap<KnowledgeTag, KnowledgeTagJsonRecord>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.TagName))
                .ReverseMap();
        }
    }
}
