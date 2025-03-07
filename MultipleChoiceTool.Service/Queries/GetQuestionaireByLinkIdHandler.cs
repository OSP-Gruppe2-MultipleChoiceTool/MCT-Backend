using MediatR;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Providers;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Queries;

internal class GetQuestionaireByLinkIdHandler : IRequestHandler<GetQuestionaireByLinkIdQuery, QuestionaireModel?>
{
    private static readonly Random _random = new();

    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IBaseReadRepository<QuestionaireModel> _questionaireReadRepository;
    private readonly IBaseReadRepository<QuestionaireLinkModel> _questionaireLinkRepository;

    public GetQuestionaireByLinkIdHandler(
        IDateTimeProvider dateTimeProvider,
        IBaseReadRepository<QuestionaireModel> questionaireReadRepository,
        IBaseReadRepository<QuestionaireLinkModel> questionaireLinkRepository)
    {
        _dateTimeProvider = dateTimeProvider;
        _questionaireReadRepository = questionaireReadRepository;
        _questionaireLinkRepository = questionaireLinkRepository;
    }

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

    private bool IsLinkExpired(QuestionaireLinkModel link)
    {
        var currentDateTime = _dateTimeProvider.UtcNow.Date;
        var expirationDateTime = link.ExpirationDate.ToDateTime(TimeOnly.MinValue);
        return currentDateTime > expirationDateTime;
    }

    private static QuestionaireModel ShuffleStatementSets(QuestionaireModel questionaire)
    {
        var shuffledStatementSets = questionaire.StatementSets
            .OrderBy(statementSet => _random.Next())
            .Select(ShuffleStatements)
            .ToList();

        return questionaire with { StatementSets = shuffledStatementSets };
    }

    private static StatementSetModel ShuffleStatements(StatementSetModel statementSet)
    {
        var shuffledStatements = statementSet.Statements
            .OrderBy(statement => _random.Next())
            .ToList();

        return statementSet with { Statements = shuffledStatements };
    }
}
