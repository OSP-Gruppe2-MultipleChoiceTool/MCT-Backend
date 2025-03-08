using MediatR;

namespace MultipleChoiceTool.Core.Commands;

/// <summary>
/// Command to export a questionnaire to RTF format.
/// </summary>
/// <param name="QuestionaireId">The ID of the questionnaire to export.</param>
/// <returns>A string representing the RTF content of the exported questionnaire, or null if not found.</returns>
public record ExportQuestionaireToRTFCommand(Guid QuestionaireId) : IRequest<string?>;
