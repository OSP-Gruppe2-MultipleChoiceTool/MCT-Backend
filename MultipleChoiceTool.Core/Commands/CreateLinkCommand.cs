using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

/// <summary>
/// Command to create a new link.
/// </summary>
/// <param name="QuestionaireId">The ID of the questionnaire associated with the link.</param>
/// <param name="ExpirationDate">The expiration date of the link.</param>
/// <returns>A <see cref="QuestionaireLinkModel"/> representing the created link.</returns>
public record CreateLinkCommand(
    Guid QuestionaireId,
    DateOnly ExpirationDate
) : IRequest<QuestionaireLinkModel>;
