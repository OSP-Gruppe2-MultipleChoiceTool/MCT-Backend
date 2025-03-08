using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

/// <summary>
/// Command to delete an existing link.
/// </summary>
/// <param name="LinkId">The ID of the link to delete.</param>
/// <returns>A <see cref="QuestionaireLinkModel"/> representing the deleted link, or null if not found.</returns>
public record DeleteLinkCommand(Guid LinkId) : IRequest<QuestionaireLinkModel?>;
