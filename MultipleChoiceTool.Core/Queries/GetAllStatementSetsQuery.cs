using MediatR;
using MultipleChoiceTool.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceTool.Core.Queries
{
    public record GetAllStatementSetsQuery(Guid QuestionaireId) : IRequest<IEnumerable<StatementSetModel>?>;
}
