using MediatR;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Queries;

internal class GetAllQuestionairesQueryHandler : IRequestHandler<GetAllQuestionairesQuery, IEnumerable<QuestionaireModel>>
{
    private readonly IBaseReadRepository<QuestionaireModel> _questionaireReadRepository;

    public GetAllQuestionairesQueryHandler(
        IBaseReadRepository<QuestionaireModel> questionaireReadRepository)
    {
        _questionaireReadRepository = questionaireReadRepository;
    }

    public async Task<IEnumerable<QuestionaireModel>> Handle(GetAllQuestionairesQuery request, CancellationToken cancellationToken)
    {
        return await _questionaireReadRepository.FindAllAsync(true, cancellationToken);
    }
}
