using MediatR;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceTool.Service.Queries
{
    internal class GetAllStatementSetsQueryHandler : IRequestHandler<GetAllStatementSetsQuery, IEnumerable<StatementSetModel>?>
    {
        private readonly IBaseReadRepository<QuestionaireModel> _questionaireReadRepository;
        private readonly IMediator _mediator;

        public GetAllStatementSetsQueryHandler(
            IBaseReadRepository<QuestionaireModel> questionaireReadRepository,
            IMediator mediator)
        {
            _questionaireReadRepository = questionaireReadRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<StatementSetModel>?> Handle(GetAllStatementSetsQuery request, CancellationToken cancellationToken)
        {
            var questionaireModel = await _questionaireReadRepository.FindByIdAsync(request.QuestionaireId, cancellationToken);
            if (questionaireModel == null)
            {
                return null;
            }

            return questionaireModel.StatementSets;
        }
    }
}
