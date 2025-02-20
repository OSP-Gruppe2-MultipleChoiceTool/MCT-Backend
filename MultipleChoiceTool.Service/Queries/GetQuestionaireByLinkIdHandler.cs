using MediatR;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Queries;

internal class GetQuestionaireByLinkIdHandler : IRequestHandler<GetQuestionaireByLinkIdQuery, QuestionaireModel?>
{
    private readonly IBaseReadRepository<QuestionaireModel> _questionaireReadRepository;
    private readonly IBaseReadRepository<QuestionaireLinkModel> _questionaireLinkRepository;

    public GetQuestionaireByLinkIdHandler(
        IBaseReadRepository<QuestionaireModel> questionaireReadRepository,
        IBaseReadRepository<QuestionaireLinkModel> questionaireLinkRepository)
    {
        _questionaireReadRepository = questionaireReadRepository;
        _questionaireLinkRepository = questionaireLinkRepository;
    }

    public async Task<QuestionaireModel?> Handle(GetQuestionaireByLinkIdQuery request, CancellationToken cancellationToken)
    {
        var link = await _questionaireLinkRepository.FindByIdAsync(request.LinkId, cancellationToken);
        if (link == null)
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
}
