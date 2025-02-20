using AutoMapper;
using MultipleChoiceTool.API.Dtos.Responses;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.API.Mappings;

public class ApiMappings : Profile
{
    public ApiMappings()
    {
        CreateMap<QuestionaireLinkModel, QuestionaireLinkResponseDto>();
        CreateMap<QuestionaireModel, QuestionaireResponseDto>();
        CreateMap<StatementModel, StatementResponseDto>()
            .ForMember(dto => dto.Statement, cfg => cfg.MapFrom(src => src.Content));
        CreateMap<StatementSetModel, StatementSetResponseDto>();
        CreateMap<StatementTypeModel, StatementTypeResponseDto>();
    }
}
