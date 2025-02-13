using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands
{
    public class CreateStatementSetCommandHandlers : IRequestHandler<CreateStatementSetCommand, StatementSetModel?>
    {
        private readonly IBaseWriteRepository<StatementSetModel> _statementSetWriteRepository;
        private readonly IMediator _mediator;

        public CreateStatementSetCommandHandlers(
            IBaseWriteRepository<StatementSetModel> statementSetWriteRepository,
            IMediator mediator)
        {
            _statementSetWriteRepository = statementSetWriteRepository;
            _mediator = mediator;
        }

        public async Task<StatementSetModel?> Handle(CreateStatementSetCommand request, CancellationToken cancellationToken)
        {
            var questionaire = await _mediator.Send(new GetQuestionaireByIdQuery(request.QuestionaireId), cancellationToken);
            if (questionaire == null)
            {
                return null;
            }

            request.StatementSet.QuestionaireId = questionaire.Id;

            return await _statementSetWriteRepository.CreateAsync(request.StatementSet, cancellationToken);
        }
    }
}
