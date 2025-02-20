using MediatR;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Queries;

internal class GetAllLinksQueryHandler : IRequestHandler<GetAllLinksQuery, IEnumerable<QuestionaireLinkModel>?>
{
    private readonly IBaseReadRepository<QuestionaireModel> _questionaireRepository;

    public GetAllLinksQueryHandler(
        IBaseReadRepository<QuestionaireModel> questionaireRepository)
    {
        _questionaireRepository = questionaireRepository;
    }

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
