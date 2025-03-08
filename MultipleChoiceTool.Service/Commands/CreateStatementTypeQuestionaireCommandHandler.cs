using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

/// <summary>
/// Handles the creation of a new questionnaire based on a statement type.
/// </summary>
internal class CreateStatementTypeQuestionaireCommandHandler : IRequestHandler<CreateStatementTypeQuestionaireCommand, QuestionaireModel>
{
    private readonly IStatementSetReadRepository _statementSetReadRepository;
    private readonly IBaseWriteRepository<QuestionaireModel> _questionaireWriteRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateStatementTypeQuestionaireCommandHandler"/> class.
    /// </summary>
    /// <param name="statementSetReadRepository">The repository to read statement sets from.</param>
    /// <param name="questionaireWriteRepository">The repository to write questionnaires to.</param>
    public CreateStatementTypeQuestionaireCommandHandler(
        IStatementSetReadRepository statementSetReadRepository,
        IBaseWriteRepository<QuestionaireModel> questionaireWriteRepository)
    {
        _statementSetReadRepository = statementSetReadRepository;
        _questionaireWriteRepository = questionaireWriteRepository;
    }

    /// <summary>
    /// Handles the request to create a new questionnaire based on a statement type.
    /// </summary>
    /// <param name="request">The request containing the statement type ID and title of the questionnaire.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The created questionnaire model.</returns>
    public async Task<QuestionaireModel> Handle(CreateStatementTypeQuestionaireCommand request, CancellationToken cancellationToken)
    {
        var statementSets = await _statementSetReadRepository.FindStatementSetsByTypeIdAsync(request.StatementTypeId, true, cancellationToken);

        var uniqueStatements = RemoveDuplicateStatementSets(statementSets);
        var unboundUniqueStatementSets = UnbindStatementSetsFromDb(uniqueStatements);

        return await CreateQuestionaireAsync(request.Title, unboundUniqueStatementSets, cancellationToken);
    }

    /// <summary>
    /// Creates a new questionnaire with the given title and statement sets.
    /// </summary>
    /// <param name="title">The title of the questionnaire.</param>
    /// <param name="statementSets">The statement sets to include in the questionnaire.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The created questionnaire model.</returns>
    private async Task<QuestionaireModel> CreateQuestionaireAsync(string title, IEnumerable<StatementSetModel> statementSets, CancellationToken cancellationToken)
    {
        var questionaire = new QuestionaireModel(title)
        {
            StatementSets = statementSets.ToList()
        };

        return await _questionaireWriteRepository.CreateAsync(questionaire, true, cancellationToken);
    }

    /// <summary>
    /// Removes duplicate statement sets based on their content.
    /// </summary>
    /// <param name="statementSets">The statement sets to process.</param>
    /// <returns>A collection of unique statement sets.</returns>
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

    /// <summary>
    /// Generates a unique key for a collection of statements based on their content and correctness.
    /// </summary>
    /// <param name="statements">The statements to process.</param>
    /// <returns>A unique key representing the statements.</returns>
    private static string GenerateContentKey(IEnumerable<StatementModel> statements)
    {
        var statementKeys = statements
            .Select(statement => $"{statement.IsCorrect}|{statement.Content}")
            .OrderBy(key => key);

        return string.Join(";", statementKeys);
    }

    /// <summary>
    /// Unbinds statement sets from the database by resetting their IDs and related properties.
    /// </summary>
    /// <param name="statementSets">The statement sets to unbind.</param>
    /// <returns>A list of unbound statement sets.</returns>
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

    /// <summary>
    /// Unbinds statements from the database by resetting their IDs and related properties.
    /// </summary>
    /// <param name="statements">The statements to unbind.</param>
    /// <returns>A list of unbound statements.</returns>
    private static List<StatementModel> UnbindStatementsFromDb(ICollection<StatementModel> statements)
    {
        return statements.Select(statement => statement with
        {
            Id = Guid.Empty,
            StatementSetId = Guid.Empty
        }).ToList();
    }
}
