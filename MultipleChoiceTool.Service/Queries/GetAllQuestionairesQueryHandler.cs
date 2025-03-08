using MediatR;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Queries;

/// <summary>
/// Handles the retrieval of all questionnaires.
/// </summary>
internal class GetAllQuestionairesQueryHandler : IRequestHandler<GetAllQuestionairesQuery, IEnumerable<QuestionaireModel>>
{
    private readonly IBaseReadRepository<QuestionaireModel> _questionaireReadRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllQuestionairesQueryHandler"/> class.
    /// </summary>
    /// <param name="questionaireReadRepository">The repository to read questionnaires from.</param>
    public GetAllQuestionairesQueryHandler(
        IBaseReadRepository<QuestionaireModel> questionaireReadRepository)
    {
        _questionaireReadRepository = questionaireReadRepository;
    }

    /// <summary>
    /// Handles the request to retrieve all questionnaires.
    /// </summary>
    /// <param name="request">The request to retrieve all questionnaires.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A collection of questionnaire models.</returns>
    public async Task<IEnumerable<QuestionaireModel>> Handle(GetAllQuestionairesQuery request, CancellationToken cancellationToken)
    {
        return await _questionaireReadRepository.FindAllAsync(true, cancellationToken);
    }
}
