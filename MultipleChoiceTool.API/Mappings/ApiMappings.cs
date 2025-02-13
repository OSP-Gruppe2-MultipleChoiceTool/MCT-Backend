using AutoMapper;
using MultipleChoiceTool.API.Dtos;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.API.Mappings;

public class ApiMappings : Profile
{
    public ApiMappings()
    {
        CreateMap<QuestionaireModel, QuestionaireDto>()
            .ReverseMap();

        CreateMap<QuestionaireLinkModel, QuestionaireLinkDto>()
            .ReverseMap();

        CreateMap<StatementModel, StatementDto>()
            .ReverseMap();

        CreateMap<StatementSetModel, StatementSetDto>()
            .ReverseMap();

        CreateMap<StatementTypeModel, StatementTypeDto>()
            .ReverseMap();
    }
}
