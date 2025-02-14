using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

internal class CreateLinkCommandHandler : IRequestHandler<CreateLinkCommand, QuestionaireLinkModel?>
{
    private readonly IBaseWriteRepository<QuestionaireLinkModel> _linkWriteRepository;
    private readonly IMediator _mediator;

    public CreateLinkCommandHandler(
        IBaseWriteRepository<QuestionaireLinkModel> linkWriteRepository,
        IMediator mediator)
    {
        _linkWriteRepository = linkWriteRepository;
        _mediator = mediator;
    }

    public async Task<QuestionaireLinkModel?> Handle(CreateLinkCommand request, CancellationToken cancellationToken)
    {
        var questionaire = await _mediator.Send(new GetQuestionaireByIdQuery(request.QuestionaireId));
        if (questionaire == null)
        {
            return null;
        }

        request.Link.QuestionaireId = questionaire.Id;

        return await _linkWriteRepository.CreateAsync(request.Link, cancellationToken);
    }
}
