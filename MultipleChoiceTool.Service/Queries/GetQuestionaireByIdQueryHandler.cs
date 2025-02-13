using MediatR;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Queries;

internal class GetQuestionaireByIdQueryHandler : IRequestHandler<GetQuestionaireByIdQuery, QuestionaireModel?>
{
    private readonly IBaseReadRepository<QuestionaireModel> _questionaireReadRepository;

    public GetQuestionaireByIdQueryHandler(
        IBaseReadRepository<QuestionaireModel> questionaireReadRepository)
    {
        _questionaireReadRepository = questionaireReadRepository;
    }

    public async Task<QuestionaireModel?> Handle(GetQuestionaireByIdQuery request, CancellationToken cancellationToken)
    {
        return await _questionaireReadRepository.FindByIdAsync(request.Id, cancellationToken);
    }
}
