using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

internal class UpdateQuestionaireCommandHandler : IRequestHandler<UpdateQuestionaireCommand, QuestionaireModel?>
{
    private readonly IBaseReadRepository<QuestionaireModel> _questionaireReadRepository;
    private readonly IBaseWriteRepository<QuestionaireModel> _questionaireWriteRepository;

    public UpdateQuestionaireCommandHandler(
        IBaseReadRepository<QuestionaireModel> questionaireReadRepository,
        IBaseWriteRepository<QuestionaireModel> questionaireWriteRepository)
    {
        _questionaireReadRepository = questionaireReadRepository;
        _questionaireWriteRepository = questionaireWriteRepository;
    }

    public async Task<QuestionaireModel?> Handle(UpdateQuestionaireCommand request, CancellationToken cancellationToken)
    {
        var questionaire = await _questionaireReadRepository.FindByIdAsync(request.QuestionaireId, cancellationToken);
        if (questionaire == null)
        {
            return null;
        }

        if (!string.IsNullOrWhiteSpace(request.Title))
        {
            questionaire.Title = request.Title;
        }

        return await _questionaireWriteRepository.UpdateAsync(questionaire, true, cancellationToken);
    }
}
