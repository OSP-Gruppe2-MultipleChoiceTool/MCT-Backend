using MediatR;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Providers;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Queries;

/// <summary>
/// Handles the retrieval of a questionnaire by its link ID.
/// </summary>
internal class GetQuestionaireByLinkIdHandler : IRequestHandler<GetQuestionaireByLinkIdQuery, QuestionaireModel?>
{
    private static readonly Random _random = new();

    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IBaseReadRepository<QuestionaireModel> _questionaireReadRepository;
    private readonly IBaseReadRepository<QuestionaireLinkModel> _questionaireLinkRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetQuestionaireByLinkIdHandler"/> class.
    /// </summary>
    /// <param name="dateTimeProvider">The provider for date and time operations.</param>
    /// <param name="questionaireReadRepository">The repository to read questionnaires from.</param>
    /// <param name="questionaireLinkRepository">The repository to read questionnaire links from.</param>
    public GetQuestionaireByLinkIdHandler(
        IDateTimeProvider dateTimeProvider,
        IBaseReadRepository<QuestionaireModel> questionaireReadRepository,
        IBaseReadRepository<QuestionaireLinkModel> questionaireLinkRepository)
    {
        _dateTimeProvider = dateTimeProvider;
        _questionaireReadRepository = questionaireReadRepository;
        _questionaireLinkRepository = questionaireLinkRepository;
    }

    /// <summary>
    /// Handles the request to retrieve a questionnaire by its link ID.
    /// </summary>
    /// <param name="request">The request containing the link ID.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The questionnaire model if found and not expired; otherwise, null.</returns>
    public async Task<QuestionaireModel?> Handle(GetQuestionaireByLinkIdQuery request, CancellationToken cancellationToken)
    {
        var link = await _questionaireLinkRepository.FindByIdAsync(request.LinkId, cancellationToken);
        if (link == null || IsLinkExpired(link))
        {
            return null;
        }

        var questionaire = await _questionaireReadRepository.FindByIdAsync(link.QuestionaireId, true, cancellationToken);
        if (questionaire == null)
        {
            return null;
        }

        if (request.IsExam)
        {
            questionaire = ShuffleStatementSets(questionaire);
        }

        return questionaire;
    }

    /// <summary>
    /// Determines whether the link is expired.
    /// </summary>
    /// <param name="link">The questionnaire link model.</param>
    /// <returns>True if the link is expired; otherwise, false.</returns>
    private bool IsLinkExpired(QuestionaireLinkModel link)
    {
        var currentDateTime = _dateTimeProvider.UtcNow.Date;
        var expirationDateTime = link.ExpirationDate.ToDateTime(TimeOnly.MinValue);
        return currentDateTime > expirationDateTime;
    }

    /// <summary>
    /// Shuffles the statement sets within the questionnaire.
    /// </summary>
    /// <param name="questionaire">The questionnaire model.</param>
    /// <returns>The questionnaire model with shuffled statement sets.</returns>
    private static QuestionaireModel ShuffleStatementSets(QuestionaireModel questionaire)
    {
        var shuffledStatementSets = questionaire.StatementSets
            .OrderBy(statementSet => _random.Next())
            .Select(ShuffleStatements)
            .ToList();

        return questionaire with { StatementSets = shuffledStatementSets };
    }

    /// <summary>
    /// Shuffles the statements within a statement set.
    /// </summary>
    /// <param name="statementSet">The statement set model.</param>
    /// <returns>The statement set model with shuffled statements.</returns>
    private static StatementSetModel ShuffleStatements(StatementSetModel statementSet)
    {
        var shuffledStatements = statementSet.Statements
            .OrderBy(statement => _random.Next())
            .ToList();

        return statementSet with { Statements = shuffledStatements };
    }
}
