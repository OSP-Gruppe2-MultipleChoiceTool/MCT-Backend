using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

/// <summary>
/// Handles the update of a questionnaire link.
/// </summary>
internal class UpdateLinkCommandHandler : IRequestHandler<UpdateLinkCommand, QuestionaireLinkModel?>
{
    private readonly IBaseReadRepository<QuestionaireLinkModel> _linkReadRepository;
    private readonly IBaseWriteRepository<QuestionaireLinkModel> _linkWriteRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateLinkCommandHandler"/> class.
    /// </summary>
    /// <param name="linkReadRepository">The repository to read links from.</param>
    /// <param name="linkWriteRepository">The repository to write links to.</param>
    public UpdateLinkCommandHandler(
        IBaseReadRepository<QuestionaireLinkModel> linkReadRepository,
        IBaseWriteRepository<QuestionaireLinkModel> linkWriteRepository)
    {
        _linkReadRepository = linkReadRepository;
        _linkWriteRepository = linkWriteRepository;
    }

    /// <summary>
    /// Handles the request to update a questionnaire link.
    /// </summary>
    /// <param name="request">The request containing the details of the link to update.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The updated link model if successful; otherwise, null.</returns>
    public async Task<QuestionaireLinkModel?> Handle(UpdateLinkCommand request, CancellationToken cancellationToken)
    {
        var link = await _linkReadRepository.FindByIdAsync(request.LinkId, cancellationToken);
        if (link == null)
        {
            return null;
        }

        if (request.ExpirationDate != null)
        {
            link.ExpirationDate = request.ExpirationDate.Value;
        }

        return await _linkWriteRepository.UpdateAsync(link, true, cancellationToken);
    }
}
