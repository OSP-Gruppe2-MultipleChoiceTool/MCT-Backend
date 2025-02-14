using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

internal class UpdateLinkCommandHandler : IRequestHandler<UpdateLinkCommand, QuestionaireLinkModel?>
{
    private readonly IBaseReadRepository<QuestionaireLinkModel> _linkReadRepository;
    private readonly IBaseWriteRepository<QuestionaireLinkModel> _linkWriteRepository;

    public UpdateLinkCommandHandler(
        IBaseReadRepository<QuestionaireLinkModel> linkReadRepository,
        IBaseWriteRepository<QuestionaireLinkModel> linkWriteRepository)
    {
        _linkReadRepository = linkReadRepository;
        _linkWriteRepository = linkWriteRepository;
    }

    public async Task<QuestionaireLinkModel?> Handle(UpdateLinkCommand request, CancellationToken cancellationToken)
    {
        var link = await _linkReadRepository.FindByIdAsync(request.LinkId, cancellationToken);
        if (link == null)
        {
            return null;
        }

        if (request.Link.ExpirationDate != default)
        {
            link.ExpirationDate = request.Link.ExpirationDate;
        }

        return await _linkWriteRepository.UpdateAsync(link, cancellationToken);
    }
}
