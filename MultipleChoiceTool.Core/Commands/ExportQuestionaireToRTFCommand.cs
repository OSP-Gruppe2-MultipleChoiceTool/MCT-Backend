using MediatR;

namespace MultipleChoiceTool.Core.Commands;

public record ExportQuestionaireToRTFCommand(Guid QuestionaireId) : IRequest<string?>;
