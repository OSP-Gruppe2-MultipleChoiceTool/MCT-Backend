using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

/// <summary>
/// Handles the update of a questionnaire.
/// </summary>
internal class UpdateQuestionaireCommandHandler : IRequestHandler<UpdateQuestionaireCommand, QuestionaireModel?>
{
    private readonly IBaseReadRepository<QuestionaireModel> _questionaireReadRepository;
    private readonly IBaseWriteRepository<QuestionaireModel> _questionaireWriteRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateQuestionaireCommandHandler"/> class.
    /// </summary>
    /// <param name="questionaireReadRepository">The repository to read questionnaires from.</param>
    /// <param name="questionaireWriteRepository">The repository to write questionnaires to.</param>
    public UpdateQuestionaireCommandHandler(
        IBaseReadRepository<QuestionaireModel> questionaireReadRepository,
        IBaseWriteRepository<QuestionaireModel> questionaireWriteRepository)
    {
        _questionaireReadRepository = questionaireReadRepository;
        _questionaireWriteRepository = questionaireWriteRepository;
    }

    /// <summary>
    /// Handles the request to update a questionnaire.
    /// </summary>
    /// <param name="request">The request containing the details of the questionnaire to update.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The updated questionnaire model if successful; otherwise, null.</returns>
    public async Task<QuestionaireModel?> Handle(UpdateQuestionaireCommand request, CancellationToken cancellationToken)
    {
        var questionaire = await _questionaireReadRepository.FindByIdAsync(request.QuestionaireId, cancellationToken);
        if (questionaire == null)
        {
            return null;
        }

        if (!string.IsNullOrWhiteSpace(request.Title))
        {
            questionaire.Title = request.Title;
        }

        return await _questionaireWriteRepository.UpdateAsync(questionaire, true, cancellationToken);
    }
}
