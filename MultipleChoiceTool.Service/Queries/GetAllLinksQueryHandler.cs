using MediatR;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Queries;

/// <summary>
/// Handles the retrieval of all links for a given questionnaire.
/// </summary>
internal class GetAllLinksQueryHandler : IRequestHandler<GetAllLinksQuery, IEnumerable<QuestionaireLinkModel>?>
{
    private readonly IBaseReadRepository<QuestionaireModel> _questionaireRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllLinksQueryHandler"/> class.
    /// </summary>
    /// <param name="questionaireRepository">The repository to read questionnaires from.</param>
    public GetAllLinksQueryHandler(
        IBaseReadRepository<QuestionaireModel> questionaireRepository)
    {
        _questionaireRepository = questionaireRepository;
    }

    /// <summary>
    /// Handles the request to retrieve all links for a given questionnaire.
    /// </summary>
    /// <param name="request">The request containing the questionnaire ID.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A collection of questionnaire link models if the questionnaire is found; otherwise, null.</returns>
    public async Task<IEnumerable<QuestionaireLinkModel>?> Handle(GetAllLinksQuery request, CancellationToken cancellationToken)
    {
        var questionaire = await _questionaireRepository.FindByIdAsync(request.QuestionaireId, true, cancellationToken);
        if (questionaire == null)
        {
            return null;
        }

        return questionaire.Links;
    }
}
