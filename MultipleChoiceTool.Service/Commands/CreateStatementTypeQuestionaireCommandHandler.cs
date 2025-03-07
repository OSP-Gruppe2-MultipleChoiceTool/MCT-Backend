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
        var statementSets = await _statementSetReadRepository.FindStatementSetsByTypeIdAsync(request.StatementTypeId, true, cancellationToken);

        var uniqueStatements = RemoveDuplicateStatementSets(statementSets);
        var unboundUniqueStatementSets = UnbindStatementSetsFromDb(uniqueStatements);

        return await CreateQuestionaireAsync(request.Title, unboundUniqueStatementSets, cancellationToken);
    }

    private async Task<QuestionaireModel> CreateQuestionaireAsync(string title, IEnumerable<StatementSetModel> statementSets, CancellationToken cancellationToken)
    {
        var questionaire = new QuestionaireModel(title)
        {
            StatementSets = statementSets.ToList()
        };

        return await _questionaireWriteRepository.CreateAsync(questionaire, true, cancellationToken);
    }

    private static IEnumerable<StatementSetModel> RemoveDuplicateStatementSets(IEnumerable<StatementSetModel> statementSets)
    {
        return statementSets.GroupBy(statementSet => new
        {
            StatementTypeId = statementSet.StatementTypeId,
            Explaination = statementSet.Explaination,
            StatementImage = statementSet.StatementImage,
            Statements = GenerateContentKey(statementSet.Statements)
        }).Select(group => group.First());
    }

    private static string GenerateContentKey(IEnumerable<StatementModel> statements)
    {
        var statementKeys = statements
            .Select(statement => $"{statement.IsCorrect}|{statement.Content}")
            .OrderBy(key => key);

        return string.Join(";", statementKeys);
    }

    private static List<StatementSetModel> UnbindStatementSetsFromDb(IEnumerable<StatementSetModel> statementSets)
    {
        return statementSets.Select(statementSet => statementSet with 
        { 
            Id = Guid.Empty,
            QuestionaireId = Guid.Empty,
            StatementType = null,
            Statements = UnbindStatementsFromDb(statementSet.Statements)
        }).ToList();
    }

    private static List<StatementModel> UnbindStatementsFromDb(ICollection<StatementModel> statements)
    {
        return statements.Select(statement => statement with
        {
            Id = Guid.Empty,
            StatementSetId = Guid.Empty
        }).ToList();
    }
}
