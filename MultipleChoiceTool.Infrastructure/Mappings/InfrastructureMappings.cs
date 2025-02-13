using AutoMapper;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Infrastructure.Entities;

namespace MultipleChoiceTool.Infrastructure.Mappings;

internal class InfrastructureMappings : Profile
{
    public InfrastructureMappings()
    {
        CreateMap<QuestionaireEntity, QuestionaireModel>().ReverseMap();
    }
}
