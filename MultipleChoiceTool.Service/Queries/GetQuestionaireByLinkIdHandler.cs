using MediatR;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Providers;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Queries;

internal class GetQuestionaireByLinkIdHandler : IRequestHandler<GetQuestionaireByLinkIdQuery, QuestionaireModel?>
{
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
            var random = new Random();
            var shuffledStatementSets = questionaire.StatementSets.OrderBy(x => random.Next()).ToList();
            questionaire = questionaire with { StatementSets = shuffledStatementSets };
        }

        return questionaire;
    }

    private bool IsLinkExpired(QuestionaireLinkModel link)
    {
        var currentDateTime = _dateTimeProvider.UtcNow.Date;
        var expirationDateTime = link.ExpirationDate.ToDateTime(TimeOnly.MinValue);
        return currentDateTime > expirationDateTime;
    }
}
