using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

internal class DeleteLinkCommandHandler : IRequestHandler<DeleteLinkCommand, QuestionaireLinkModel?>
{
    private readonly IBaseReadRepository<QuestionaireLinkModel> _linkReadRepository;
    private readonly IBaseWriteRepository<QuestionaireLinkModel> _linkWriteRepository;

    public DeleteLinkCommandHandler(
        IBaseReadRepository<QuestionaireLinkModel> linkReadRepository,
        IBaseWriteRepository<QuestionaireLinkModel> linkWriteRepository)
    {
        _linkReadRepository = linkReadRepository;
        _linkWriteRepository = linkWriteRepository;
    }

    public async Task<QuestionaireLinkModel?> Handle(DeleteLinkCommand request, CancellationToken cancellationToken)
    {
        var link = await _linkReadRepository.FindByIdAsync(request.LinkId);
        if (link == null)
        {
            return null;
        }

        return await _linkWriteRepository.DeleteAsync(link);
    }
}
