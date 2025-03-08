using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

/// <summary>
/// Handles the deletion of a link.
/// </summary>
internal class DeleteLinkCommandHandler : IRequestHandler<DeleteLinkCommand, QuestionaireLinkModel?>
{
    private readonly IBaseReadRepository<QuestionaireLinkModel> _linkReadRepository;
    private readonly IBaseWriteRepository<QuestionaireLinkModel> _linkWriteRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteLinkCommandHandler"/> class.
    /// </summary>
    /// <param name="linkReadRepository">The repository to read links from.</param>
    /// <param name="linkWriteRepository">The repository to write links to.</param>
    public DeleteLinkCommandHandler(
        IBaseReadRepository<QuestionaireLinkModel> linkReadRepository,
        IBaseWriteRepository<QuestionaireLinkModel> linkWriteRepository)
    {
        _linkReadRepository = linkReadRepository;
        _linkWriteRepository = linkWriteRepository;
    }

    /// <summary>
    /// Handles the request to delete a link.
    /// </summary>
    /// <param name="request">The request containing the link ID.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The deleted questionnaire link model if successful; otherwise, null.</returns>
    public async Task<QuestionaireLinkModel?> Handle(DeleteLinkCommand request, CancellationToken cancellationToken)
    {
        var link = await _linkReadRepository.FindByIdAsync(request.LinkId, cancellationToken);
        if (link == null)
        {
            return null;
        }

        return await _linkWriteRepository.DeleteAsync(link, true, cancellationToken);
    }
}
