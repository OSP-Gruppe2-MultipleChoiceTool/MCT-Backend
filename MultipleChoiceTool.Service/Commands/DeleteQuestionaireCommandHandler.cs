using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

internal class DeleteQuestionaireCommandHandler : IRequestHandler<DeleteQuestionaireCommand, QuestionaireModel?>
{
    private readonly IBaseWriteRepository<QuestionaireModel> _questionaireWriteRepository;
    private readonly IMediator _mediator;

    public DeleteQuestionaireCommandHandler(
        IBaseWriteRepository<QuestionaireModel> questionaireWriteRepository,
        IMediator mediator)
    {
        _questionaireWriteRepository = questionaireWriteRepository;
        _mediator = mediator;
    }

    public async Task<QuestionaireModel?> Handle(DeleteQuestionaireCommand request, CancellationToken cancellationToken)
    {
        var questionaire = await _mediator.Send(new GetQuestionaireByIdQuery(request.QuestionaireId));
        if (questionaire == null)
        {
            return null;
        }

        return await _questionaireWriteRepository.DeleteAsync(questionaire, cancellationToken);
    }
}
