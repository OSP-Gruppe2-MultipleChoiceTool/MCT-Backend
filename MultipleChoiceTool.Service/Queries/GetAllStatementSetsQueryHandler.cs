using MediatR;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Queries
{
    internal class GetAllStatementSetsQueryHandler : IRequestHandler<GetAllStatementSetsQuery, IEnumerable<StatementSetModel>?>
    {
        private readonly IBaseReadRepository<QuestionaireModel> _questionaireReadRepository;

        public GetAllStatementSetsQueryHandler(
            IBaseReadRepository<QuestionaireModel> questionaireReadRepository)
        {
            _questionaireReadRepository = questionaireReadRepository;
        }

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
