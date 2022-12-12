using AutoMapper;
using MyKnowledgeManager.WebApi.ApiModels;

namespace MyKnowledgeManager.WebApi.MappingConfigurations
{
    public class KnowledgeTagProfile : Profile
    {
        public KnowledgeTagProfile()
        {
            CreateMap<KnowledgeTag, KnowledgeTagDTO>();
            CreateMap<KnowledgeTagDTO, KnowledgeTag>()
                .ConstructUsing(x => new KnowledgeTag(x.TagName, x.UserId, x.CreatedDate, x.UpdatedDate));
        }
    }
}
