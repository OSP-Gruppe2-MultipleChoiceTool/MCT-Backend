using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;
using MultipleChoiceTool.Service.Helpers;

namespace MultipleChoiceTool.Service.Commands;

/// <summary>
/// Handles the export of a questionnaire to RTF format.
/// </summary>
internal class ExportQuestionaireToRTFCommandHandler : IRequestHandler<ExportQuestionaireToRTFCommand, string?>
{
    private readonly IBaseReadRepository<QuestionaireModel> _questionaireReadRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExportQuestionaireToRTFCommandHandler"/> class.
    /// </summary>
    /// <param name="questionaireReadRepository">The repository to read questionnaires from.</param>
    public ExportQuestionaireToRTFCommandHandler(
        IBaseReadRepository<QuestionaireModel> questionaireReadRepository)
    {
        _questionaireReadRepository = questionaireReadRepository;
    }

    /// <summary>
    /// Handles the request to export a questionnaire to RTF format.
    /// </summary>
    /// <param name="request">The request containing the details of the questionnaire to export.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The RTF string if successful; otherwise, null.</returns>
    public async Task<string?> Handle(ExportQuestionaireToRTFCommand request, CancellationToken cancellationToken)
    {
        var questionaire = await _questionaireReadRepository.FindByIdAsync(request.QuestionaireId, true, cancellationToken);
        if (questionaire == null)
        {
            return null;
        }

        return ExportToRTF(questionaire);
    }

    /// <summary>
    /// Exports the given questionnaire to RTF format.
    /// </summary>
    /// <param name="questionaire">The questionnaire to export.</param>
    /// <returns>The RTF string.</returns>
    private static string ExportToRTF(QuestionaireModel questionaire)
    {
        var rtfBuilder = new RTFDocumentBuilder();

        AddLegendTable(rtfBuilder, questionaire.StatementSets);
        AddStatementTable(rtfBuilder, questionaire.StatementSets);

        return rtfBuilder.Build();
    }

    /// <summary>
    /// Adds the legend table to the RTF document.
    /// </summary>
    /// <param name="rtfBuilder">The RTF document builder.</param>
    /// <param name="statementSets">The statement sets of the questionnaire.</param>
    private static void AddLegendTable(RTFDocumentBuilder rtfBuilder, ICollection<StatementSetModel> statementSets)
    {
        var legendTable = rtfBuilder.AddTable();
        legendTable.AddRow([MakeRTFBold("Number"), MakeRTFBold("Meaning")]);
        legendTable.AddRow([MakeRTFBold("0"), "None of the Statements are correct"]);

        var maxStatementCount = GetMaxStatementCount(statementSets);
        var responseOptionCount = Math.Pow(2, maxStatementCount) - 1;

        for (int i = 1; i < responseOptionCount; i++)
        {
            AddLegendOptionRow(legendTable, i, maxStatementCount);
        }

        legendTable.AddRow([MakeRTFBold($"{responseOptionCount}"), "All Statements are correct"]);
    }

    /// <summary>
    /// Adds a legend option row to the legend table.
    /// </summary>
    /// <param name="legendTable">The legend table builder.</param>
    /// <param name="iteration">The current iteration number.</param>
    /// <param name="maxStatementCount">The maximum number of statements.</param>
    private static void AddLegendOptionRow(RTFTableBuilder legendTable, int iteration, int maxStatementCount)
    {
        // AI-Generated bomb!
        // This is supposed to get the correct statements for this row.
        var correctStatements = Enumerable.Range(1, maxStatementCount)
            .Where(statement => (iteration & (1 << (statement - 1))) != 0)
            .ToArray();

        var correctStatementsStr = string.Join(", ", correctStatements);

        if (correctStatements.Length == 1)
        {
            legendTable.AddRow([MakeRTFBold($"{iteration}"), $"Statement {correctStatementsStr} is correct"]);
        }
        else
        {
            legendTable.AddRow([MakeRTFBold($"{iteration}"), $"Statements {correctStatementsStr} are correct"]);
        }
    }

    /// <summary>
    /// Adds the statement table to the RTF document.
    /// </summary>
    /// <param name="rtfBuilder">The RTF document builder.</param>
    /// <param name="statementSets">The statement sets of the questionnaire.</param>
    private static void AddStatementTable(RTFDocumentBuilder rtfBuilder, IEnumerable<StatementSetModel> statementSets)
    {
        var statementTable = rtfBuilder.AddTable();

        var maxStatementCount = GetMaxStatementCount(statementSets);
        AddStatementSetHeaderRow(statementTable, maxStatementCount);

        foreach (var statementSet in statementSets)
        {
            AddStatementSetRow(statementTable, statementSet, maxStatementCount);
        }
    }

    /// <summary>
    /// Adds a statement set row to the statement table.
    /// </summary>
    /// <param name="tableBuilder">The statement table builder.</param>
    /// <param name="statementSet">The statement set to add.</param>
    /// <param name="maxStatementCount">The maximum number of statements.</param>
    private static void AddStatementSetRow(RTFTableBuilder tableBuilder, StatementSetModel statementSet, int maxStatementCount)
    {
        var padding = Enumerable
            .Range(0, maxStatementCount - statementSet.Statements.Count)
            .Select(_ => "")
            .ToArray();

        var statementContents = statementSet.Statements
            .Select(statement => statement.Content)
            .Concat(padding)
            .Concat([""])
            .ToArray();

        tableBuilder.AddRow(statementContents);
    }

    /// <summary>
    /// Adds the header row to the statement table.
    /// </summary>
    /// <param name="tableBuilder">The statement table builder.</param>
    /// <param name="statementCount">The number of statements.</param>
    private static void AddStatementSetHeaderRow(RTFTableBuilder tableBuilder, int statementCount)
    {
        var headerRow = Enumerable
            .Range(1, statementCount)
            .Select(i => MakeRTFBold($"Statement {i}"))
            .Concat([MakeRTFBold("Response")])
            .ToArray();

        tableBuilder.AddRow(headerRow);
    }

    /// <summary>
    /// Gets the maximum number of statements in the statement sets.
    /// </summary>
    /// <param name="statementSets">The statement sets.</param>
    /// <returns>The maximum number of statements.</returns>
    private static int GetMaxStatementCount(IEnumerable<StatementSetModel> statementSets)
    {
        return statementSets.Max(statementSet => statementSet.Statements.Count);
    }

    /// <summary>
    /// Makes the given text bold in RTF format.
    /// </summary>
    /// <param name="text">The text to make bold.</param>
    /// <returns>The bold RTF string.</returns>
    private static string MakeRTFBold(string text)
    {
        return $@"\b {text} \b0";
    }
}
