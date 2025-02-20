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
        CreateMap<QuestionaireRequestDto, QuestionaireModel>();

        CreateMap<StatementSetModel, StatementSetResponseDto>();
        CreateMap<StatementTypeModel, StatementTypeResponseDto>();
    }
}
