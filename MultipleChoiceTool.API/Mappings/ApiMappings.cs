using AutoMapper;
using MultipleChoiceTool.API.Dtos.Requests;
using MultipleChoiceTool.API.Dtos.Responses;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.API.Mappings;

public class ApiMappings : Profile
{
    public ApiMappings()
    {
        CreateMap<QuestionaireModel, QuestionaireResponseDto>();
        CreateMap<QuestionaireRequestDto, QuestionaireModel>();

        CreateMap<StatementSetModel, StatementSetResponseDto>();
        CreateMap<StatementSetRequestDto, StatementSetModel>();
    }
}
