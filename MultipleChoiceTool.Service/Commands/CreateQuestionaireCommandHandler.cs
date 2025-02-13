using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

public class CreateQuestionaireCommandHandler : IRequestHandler<CreateQuestionaireCommand, QuestionaireModel>
{
    private readonly IBaseWriteRepository<QuestionaireModel> _questionaireWriteRepository;

    public CreateQuestionaireCommandHandler(
        IBaseWriteRepository<QuestionaireModel> questionaireWriteRepository)
    {
        _questionaireWriteRepository = questionaireWriteRepository;
    }

    public Task<QuestionaireModel> Handle(CreateQuestionaireCommand request, CancellationToken cancellationToken)
    {
        return _questionaireWriteRepository.CreateAsync(request.Questionaire, cancellationToken);
    }
}
