using MediatR;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Queries
{
    /// <summary>
    /// Handles the retrieval of all statement sets for a given questionnaire.
    /// </summary>
    internal class GetAllStatementSetsQueryHandler : IRequestHandler<GetAllStatementSetsQuery, IEnumerable<StatementSetModel>?>
    {
        private readonly IBaseReadRepository<QuestionaireModel> _questionaireReadRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllStatementSetsQueryHandler"/> class.
        /// </summary>
        /// <param name="questionaireReadRepository">The repository to read questionnaires from.</param>
        public GetAllStatementSetsQueryHandler(
            IBaseReadRepository<QuestionaireModel> questionaireReadRepository)
        {
            _questionaireReadRepository = questionaireReadRepository;
        }

        /// <summary>
        /// Handles the request to retrieve all statement sets for a given questionnaire.
        /// </summary>
        /// <param name="request">The request containing the questionnaire ID.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A collection of statement set models if the questionnaire is found; otherwise, null.</returns>
        public async Task<IEnumerable<StatementSetModel>?> Handle(GetAllStatementSetsQuery request, CancellationToken cancellationToken)
        {
            var questionaireModel = await _questionaireReadRepository.FindByIdAsync(request.QuestionaireId, true, cancellationToken);
            if (questionaireModel == null)
            {
                return null;
            }

            return questionaireModel.StatementSets;
        }
    }
}
