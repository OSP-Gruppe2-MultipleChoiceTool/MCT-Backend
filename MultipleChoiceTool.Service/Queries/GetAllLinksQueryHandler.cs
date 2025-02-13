using MediatR;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;

namespace MultipleChoiceTool.Service.Queries;

internal class GetAllLinksQueryHandler : IRequestHandler<GetAllLinksQuery, IEnumerable<QuestionaireLinkModel>?>
{
    private readonly IMediator _mediator;
    public GetAllLinksQueryHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IEnumerable<QuestionaireLinkModel>?> Handle(GetAllLinksQuery request, CancellationToken cancellationToken)
    {
        var questionaire = await _mediator.Send(new GetQuestionaireByIdQuery(request.QuestionaireId));
        if (questionaire == null)
        {
            return null;
        }

        return questionaire.Links;
    }
}
