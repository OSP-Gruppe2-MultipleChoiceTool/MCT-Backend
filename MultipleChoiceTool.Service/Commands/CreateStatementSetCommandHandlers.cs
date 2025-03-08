using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands
{
    /// <summary>
    /// Handles the creation of a new statement set for a questionnaire.
    /// </summary>
    public class CreateStatementSetCommandHandlers : IRequestHandler<CreateStatementSetCommand, StatementSetModel?>
    {
        private readonly IBaseReadRepository<QuestionaireModel> _questionaireReadRepository;
        private readonly IBaseWriteRepository<StatementSetModel> _statementSetWriteRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateStatementSetCommandHandlers"/> class.
        /// </summary>
        /// <param name="questionaireReadRepository">The repository to read questionnaires from.</param>
        /// <param name="statementSetWriteRepository">The repository to write statement sets to.</param>
        public CreateStatementSetCommandHandlers(
            IBaseReadRepository<QuestionaireModel> questionaireReadRepository,
            IBaseWriteRepository<StatementSetModel> statementSetWriteRepository)
        {
            _questionaireReadRepository = questionaireReadRepository;
            _statementSetWriteRepository = statementSetWriteRepository;
        }

        /// <summary>
        /// Handles the request to create a new statement set for a questionnaire.
        /// </summary>
        /// <param name="request">The request containing the details of the statement set.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The created statement set model if successful; otherwise, null.</returns>
        public async Task<StatementSetModel?> Handle(CreateStatementSetCommand request, CancellationToken cancellationToken)
        {
            var questionaire = await _questionaireReadRepository.FindByIdAsync(request.QuestionaireId, cancellationToken);
            if (questionaire == null)
            {
                return null;
            }

            var statementSet = new StatementSetModel(questionaire.Id, request.StatementTypeId, request.Explaination, request.StatementImage)
            {
                Statements = request.Statements.ToList()
            };
            
            return await _statementSetWriteRepository.CreateAsync(statementSet, true, cancellationToken);
        }
    }
}
