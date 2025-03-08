using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

/// <summary>
/// Command to update an existing link.
/// </summary>
/// <param name="LinkId">The ID of the link to update.</param>
/// <param name="ExpirationDate">The new expiration date of the link.</param>
/// <returns>A <see cref="QuestionaireLinkModel"/> representing the updated link, or null if not found.</returns>
public record UpdateLinkCommand(
    Guid LinkId, 
    DateOnly? ExpirationDate
) : IRequest<QuestionaireLinkModel?>;
