using AutoMapper;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Infrastructure.Entities;

namespace MultipleChoiceTool.Infrastructure.Mappings;

internal class InfrastructureMappings : Profile
{
    public InfrastructureMappings()
    {
        CreateMap<QuestionaireModel, QuestionaireEntity>()
            .ForMember(q => q.QuestionaireLinks, opt => opt.MapFrom(src => src.Links))
            .ReverseMap()
            .ForMember(q => q.Links, opt => opt.MapFrom(src => src.QuestionaireLinks));

        CreateMap<QuestionaireLinkModel, QuestionaireLinkEntity>()
            .ReverseMap();
        
        CreateMap<StatementModel, StatementEntity>()
            .ReverseMap();

        CreateMap<StatementSetModel, StatementSetEntity>()
            .ReverseMap();
        
        CreateMap<StatementTypeModel, StatementTypeEntity>()
            .ReverseMap();
    }
}
