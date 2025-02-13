using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceTool.Service.Commands
{
    public class CreateStatementSetCommandHandlers : IRequestHandler<CreateStatementSetCommand, StatementSetModel>
    {
        private readonly IBaseWriteRepository<StatementSetModel> _statementSetWriteRepository;

        public CreateStatementSetCommandHandlers(
            IBaseWriteRepository<StatementSetModel> statementSetWriteRepository)
        {
            _statementSetWriteRepository = statementSetWriteRepository;
        }

        public Task<StatementSetModel> Handle(CreateStatementSetCommand request, CancellationToken cancellationToken)
        {
            return _statementSetWriteRepository.CreateAsync(request.StatementSet, cancellationToken);
        }
    }
}
