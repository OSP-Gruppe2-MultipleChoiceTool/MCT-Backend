using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

internal class UpdateQuestionaireCommandHandler : IRequestHandler<UpdateQuestionaireCommand, QuestionaireModel?>
{
    private readonly IBaseWriteRepository<QuestionaireModel> _questionaireWriteRepository;
    private readonly IMediator _mediator;

    public UpdateQuestionaireCommandHandler(
        IBaseWriteRepository<QuestionaireModel> questionaireWriteRepository,
        IMediator mediator)
    {
        _questionaireWriteRepository = questionaireWriteRepository;
        _mediator = mediator;
    }

    public async Task<QuestionaireModel?> Handle(UpdateQuestionaireCommand request, CancellationToken cancellationToken)
    {
        var questionaire = await _mediator.Send(new GetQuestionaireByIdQuery(request.Id));
        if (questionaire == null)
        {
            return null;
        }

        if (!string.IsNullOrWhiteSpace(request.Questionaire.Title))
        {
            questionaire.Title = request.Questionaire.Title;
        }

        return await _questionaireWriteRepository.UpdateAsync(questionaire, cancellationToken);
    }
}
