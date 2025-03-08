using AutoMapper;
using MultipleChoiceTool.API.Dtos.Requests;
using MultipleChoiceTool.API.Dtos.Responses;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.API.Mappings;

/// <summary>
/// Provides mapping configurations for API DTOs and models.
/// </summary>
public class ApiMappings : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiMappings"/> class.
    /// </summary>
    public ApiMappings()
    {
        CreateMap<QuestionaireLinkModel, QuestionaireLinkResponseDto>();
        CreateMap<QuestionaireModel, QuestionaireResponseDto>();
        CreateMap<StatementModel, StatementResponseDto>()
            .ForMember(dto => dto.Statement, cfg => cfg.MapFrom(src => src.Content));
        CreateMap<StatementSetModel, StatementSetResponseDto>();
        CreateMap<StatementTypeModel, StatementTypeResponseDto>();

        CreateMap<StatementRequestDto, StatementModel>()
            .ForMember(model => model.Content, cfg => cfg.MapFrom(src => src.Statement));
    }
}
