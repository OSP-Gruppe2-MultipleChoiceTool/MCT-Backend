using MediatR;
using MultipleChoiceTool.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceTool.Core.Commands
{
    public record DeleteStatementSetCommand(Guid QuestionaireId, Guid statementSetId) : IRequest<QuestionaireModel?>;
}
