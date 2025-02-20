using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

internal class CreateLinkCommandHandler : IRequestHandler<CreateLinkCommand, QuestionaireLinkModel?>
{
    private readonly IBaseReadRepository<QuestionaireModel> _questionaireReadRepository;
    private readonly IBaseWriteRepository<QuestionaireLinkModel> _linkWriteRepository;

    public CreateLinkCommandHandler(
        IBaseReadRepository<QuestionaireModel> questionaireReadRepository,
        IBaseWriteRepository<QuestionaireLinkModel> linkWriteRepository)
    {
        _questionaireReadRepository = questionaireReadRepository;
        _linkWriteRepository = linkWriteRepository;
    }

    public async Task<QuestionaireLinkModel?> Handle(CreateLinkCommand request, CancellationToken cancellationToken)
    {
        var questionaire = await _questionaireReadRepository.FindByIdAsync(request.QuestionaireId, cancellationToken);
        if (questionaire == null)
        {
            return null;
        }

        var link = new QuestionaireLinkModel(request.QuestionaireId, request.ExpirationDate);
        return await _linkWriteRepository.CreateAsync(link, true, cancellationToken);
    }
}
