using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

/// <summary>
/// Handles the deletion of a questionnaire.
/// </summary>
internal class DeleteQuestionaireCommandHandler : IRequestHandler<DeleteQuestionaireCommand, QuestionaireModel?>
{
    private readonly IBaseReadRepository<QuestionaireModel> _questionaireReadRepository;
    private readonly IBaseWriteRepository<QuestionaireModel> _questionaireWriteRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteQuestionaireCommandHandler"/> class.
    /// </summary>
    /// <param name="questionaireReadRepository">The repository to read questionnaires from.</param>
    /// <param name="questionaireWriteRepository">The repository to write questionnaires to.</param>
    public DeleteQuestionaireCommandHandler(
        IBaseReadRepository<QuestionaireModel> questionaireReadRepository,
        IBaseWriteRepository<QuestionaireModel> questionaireWriteRepository)
    {
        _questionaireReadRepository = questionaireReadRepository;
        _questionaireWriteRepository = questionaireWriteRepository;
    }

    /// <summary>
    /// Handles the request to delete a questionnaire.
    /// </summary>
    /// <param name="request">The request containing the questionnaire ID.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The deleted questionnaire model if successful; otherwise, null.</returns>
    public async Task<QuestionaireModel?> Handle(DeleteQuestionaireCommand request, CancellationToken cancellationToken)
    {
        var questionaire = await _questionaireReadRepository.FindByIdAsync(request.QuestionaireId, cancellationToken);
        if (questionaire == null)
        {
            return null;
        }

        return await _questionaireWriteRepository.DeleteAsync(questionaire, true, cancellationToken);
    }
}
