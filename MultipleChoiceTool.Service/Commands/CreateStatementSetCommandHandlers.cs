using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands
{
    public class CreateStatementSetCommandHandlers : IRequestHandler<CreateStatementSetCommand, StatementSetModel?>
    {
        private readonly IBaseReadRepository<QuestionaireModel> _questionaireReadRepository;
        private readonly IBaseWriteRepository<StatementSetModel> _statementSetWriteRepository;

        public CreateStatementSetCommandHandlers(
            IBaseReadRepository<QuestionaireModel> questionaireReadRepository,
            IBaseWriteRepository<StatementSetModel> statementSetWriteRepository)
        {
            _questionaireReadRepository = questionaireReadRepository;
            _statementSetWriteRepository = statementSetWriteRepository;
        }

        public async Task<StatementSetModel?> Handle(CreateStatementSetCommand request, CancellationToken cancellationToken)
        {
            var questionaire = await _questionaireReadRepository.FindByIdAsync(request.QuestionaireId, cancellationToken);
            if (questionaire == null)
            {
                return null;
            }

            var statementSet = new StatementSetModel(questionaire.Id, request.StatementTypeId, request.Explaination, request.StatementImage);
            
            foreach (var statement in request.Statements)
            {
                statementSet.Statements.Add(statement);
            }

            return await _statementSetWriteRepository.CreateAsync(statementSet, true, cancellationToken);
        }
    }
}
