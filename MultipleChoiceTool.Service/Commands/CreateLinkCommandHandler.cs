using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

/// <summary>
/// Handles the creation of a new link for a questionnaire.
/// </summary>
internal class CreateLinkCommandHandler : IRequestHandler<CreateLinkCommand, QuestionaireLinkModel?>
{
    private readonly IBaseReadRepository<QuestionaireModel> _questionaireReadRepository;
    private readonly IBaseWriteRepository<QuestionaireLinkModel> _linkWriteRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateLinkCommandHandler"/> class.
    /// </summary>
    /// <param name="questionaireReadRepository">The repository to read questionnaires from.</param>
    /// <param name="linkWriteRepository">The repository to write links to.</param>
    public CreateLinkCommandHandler(
        IBaseReadRepository<QuestionaireModel> questionaireReadRepository,
        IBaseWriteRepository<QuestionaireLinkModel> linkWriteRepository)
    {
        _questionaireReadRepository = questionaireReadRepository;
        _linkWriteRepository = linkWriteRepository;
    }

    /// <summary>
    /// Handles the request to create a new link for a questionnaire.
    /// </summary>
    /// <param name="request">The request containing the questionnaire ID and expiration date.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The created questionnaire link model if successful; otherwise, null.</returns>
    public async Task<QuestionaireLinkModel?> Handle(CreateLinkCommand request, CancellationToken cancellationToken)
    {
        var questionaire = await _questionaireReadRepository.FindByIdAsync(request.QuestionaireId, cancellationToken);
        if (questionaire == null)
        {
            return null;
        }

        var link = new QuestionaireLinkModel(request.QuestionaireId, request.ExpirationDate);
        return await _linkWriteRepository.CreateAsync(link, true, cancellationToken);
    }
}
