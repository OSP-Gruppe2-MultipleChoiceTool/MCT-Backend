using MediatR;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Queries;

/// <summary>
/// Handles the retrieval of a questionnaire by its ID.
/// </summary>
internal class GetQuestionaireByIdQueryHandler : IRequestHandler<GetQuestionaireByIdQuery, QuestionaireModel?>
{
    private readonly IBaseReadRepository<QuestionaireModel> _questionaireReadRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetQuestionaireByIdQueryHandler"/> class.
    /// </summary>
    /// <param name="questionaireReadRepository">The repository to read questionnaires from.</param>
    public GetQuestionaireByIdQueryHandler(
        IBaseReadRepository<QuestionaireModel> questionaireReadRepository)
    {
        _questionaireReadRepository = questionaireReadRepository;
    }

    /// <summary>
    /// Handles the request to retrieve a questionnaire by its ID.
    /// </summary>
    /// <param name="request">The request containing the questionnaire ID.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The questionnaire model if found; otherwise, null.</returns>
    public async Task<QuestionaireModel?> Handle(GetQuestionaireByIdQuery request, CancellationToken cancellationToken)
    {
        return await _questionaireReadRepository.FindByIdAsync(request.QuestionaireId, true, cancellationToken);
    }
}
