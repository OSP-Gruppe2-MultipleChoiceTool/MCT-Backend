using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

/// <summary>
/// Command to create a new statement type.
/// </summary>
/// <param name="Title">The title of the statement type.</param>
/// <returns>A <see cref="StatementTypeModel"/> representing the created statement type.</returns>
public record CreateStatementTypeCommand(string Title) : IRequest<StatementTypeModel>;
