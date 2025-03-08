using AutoMapper;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Infrastructure.Entities;

namespace MultipleChoiceTool.Infrastructure.Mappings;

/// <summary>
/// Provides mapping configurations between domain models and entities.
/// </summary>
internal class InfrastructureMappings : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InfrastructureMappings"/> class.
    /// </summary>
    public InfrastructureMappings()
    {
        CreateMap<QuestionaireModel, QuestionaireEntity>()
            .ForMember(entity => entity.QuestionaireLinks, opt => opt.MapFrom(src => src.Links))
            .ReverseMap()
            .ForMember(model => model.Links, opt => opt.MapFrom(src => src.QuestionaireLinks));

        CreateMap<QuestionaireLinkModel, QuestionaireLinkEntity>()
            .ReverseMap();
        
        CreateMap<StatementModel, StatementEntity>()
            .ForMember(entity => entity.Statement, opt => opt.MapFrom(src => src.Content))
            .ReverseMap()
            .ForMember(model => model.Content, opt => opt.MapFrom(src => src.Statement));

        CreateMap<StatementSetModel, StatementSetEntity>()
            .ReverseMap();
        
        CreateMap<StatementTypeModel, StatementTypeEntity>()
            .ReverseMap();
    }
}
