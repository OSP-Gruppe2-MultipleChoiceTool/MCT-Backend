using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;
using MultipleChoiceTool.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceTool.Service.Commands
{
    internal class DeleteStatementSetCommandHandler : IRequestHandler<DeleteStatementSetCommand, StatementSetModel?>
    {
        private readonly IBaseWriteRepository<QuestionaireModel> _questionaireWriteRepository;
        private readonly IMediator _mediator;

        public DeleteStatementSetCommandHandler(
            IBaseWriteRepository<QuestionaireModel> questionaireWriteRepository,
            IMediator mediator)
        {
            _questionaireWriteRepository = questionaireWriteRepository;
            _mediator = mediator;
        }

        public async Task<StatementSetModel?> Handle(DeleteStatementSetCommand request, CancellationToken cancellationToken)
        {
            var questionaire = await _mediator.Send(new GetQuestionaireByIdQuery(request.QuestionaireId));
            if (questionaire == null)
            {
                return null;
            }

            var statementSet = questionaire.StatementSets.FirstOrDefault(statementSet => statementSet.Id == request.statementSetId);
            if (statementSet == null)
            {
                return null;
            }

            questionaire.StatementSets.Remove(statementSet);
            questionaire = await _questionaireWriteRepository.UpdateAsync(questionaire, cancellationToken);

            return statementSet;
        }
    }
}
