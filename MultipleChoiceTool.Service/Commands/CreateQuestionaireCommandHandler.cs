using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

/// <summary>
/// Handles the creation of a new questionnaire.
/// </summary>
public class CreateQuestionaireCommandHandler : IRequestHandler<CreateQuestionaireCommand, QuestionaireModel>
{
    private readonly IBaseWriteRepository<QuestionaireModel> _questionaireWriteRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateQuestionaireCommandHandler"/> class.
    /// </summary>
    /// <param name="questionaireWriteRepository">The repository to write questionnaires to.</param>
    public CreateQuestionaireCommandHandler(
        IBaseWriteRepository<QuestionaireModel> questionaireWriteRepository)
    {
        _questionaireWriteRepository = questionaireWriteRepository;
    }

    /// <summary>
    /// Handles the request to create a new questionnaire.
    /// </summary>
    /// <param name="request">The request containing the title of the questionnaire.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The created questionnaire model.</returns>
    public Task<QuestionaireModel> Handle(CreateQuestionaireCommand request, CancellationToken cancellationToken)
    {
        var questionaire = new QuestionaireModel(request.Title);
        return _questionaireWriteRepository.CreateAsync(questionaire, true, cancellationToken);
    }
}
