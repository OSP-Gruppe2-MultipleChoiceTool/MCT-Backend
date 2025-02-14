using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

internal class DeleteQuestionaireCommandHandler : IRequestHandler<DeleteQuestionaireCommand, QuestionaireModel?>
{
    private readonly IBaseReadRepository<QuestionaireModel> _questionaireReadRepository;
    private readonly IBaseWriteRepository<QuestionaireModel> _questionaireWriteRepository;

    public DeleteQuestionaireCommandHandler(
        IBaseReadRepository<QuestionaireModel> questionaireReadRepository,
        IBaseWriteRepository<QuestionaireModel> questionaireWriteRepository)
    {
        _questionaireReadRepository = questionaireReadRepository;
        _questionaireWriteRepository = questionaireWriteRepository;
    }

    public async Task<QuestionaireModel?> Handle(DeleteQuestionaireCommand request, CancellationToken cancellationToken)
    {
        var questionaire = await _questionaireReadRepository.FindByIdAsync(request.QuestionaireId, cancellationToken);
        if (questionaire == null)
        {
            return null;
        }

        return await _questionaireWriteRepository.DeleteAsync(questionaire, cancellationToken);
    }
}
