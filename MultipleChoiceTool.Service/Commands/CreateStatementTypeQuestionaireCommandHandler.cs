using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

internal class CreateStatementTypeQuestionaireCommandHandler : IRequestHandler<CreateStatementTypeQuestionaireCommand, QuestionaireModel>
{
    private readonly IStatementSetReadRepository _statementSetReadRepository;
    private readonly IBaseWriteRepository<QuestionaireModel> _questionaireWriteRepository;

    public CreateStatementTypeQuestionaireCommandHandler(
        IStatementSetReadRepository statementSetReadRepository,
        IBaseWriteRepository<QuestionaireModel> questionaireWriteRepository)
    {
        _statementSetReadRepository = statementSetReadRepository;
        _questionaireWriteRepository = questionaireWriteRepository;
    }

    public async Task<QuestionaireModel> Handle(CreateStatementTypeQuestionaireCommand request, CancellationToken cancellationToken)
    {
        var statementSets = await _statementSetReadRepository.FindStatementSetsByTypeIdAsync(request.StatementTypeId, cancellationToken);
        
        var clearedStatementSets = GetStatementSetsWithClearedId(statementSets);

        return await CreateQuestionaireAsync(request.Title, clearedStatementSets, cancellationToken);
    }

    private async Task<QuestionaireModel> CreateQuestionaireAsync(string title, IEnumerable<StatementSetModel> statementSets, CancellationToken cancellationToken)
    {
        var questionaire = new QuestionaireModel(title);
        foreach (var statementSet in statementSets)
        {
            questionaire.StatementSets.Add(statementSet);
        }

        return await _questionaireWriteRepository.CreateAsync(questionaire, true, cancellationToken);
    }

    private static IEnumerable<StatementSetModel> GetStatementSetsWithClearedId(IEnumerable<StatementSetModel> statementSets)
    {
        return statementSets.Select(statementSet => statementSet with { Id = Guid.Empty });
    }
}
