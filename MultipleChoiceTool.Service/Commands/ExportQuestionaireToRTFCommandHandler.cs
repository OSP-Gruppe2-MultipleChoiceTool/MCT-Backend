using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;
using MultipleChoiceTool.Service.Helpers;

namespace MultipleChoiceTool.Service.Commands;

internal class ExportQuestionaireToRTFCommandHandler : IRequestHandler<ExportQuestionaireToRTFCommand, string?>
{
    private readonly IBaseReadRepository<QuestionaireModel> _questionaireReadRepository;

    public ExportQuestionaireToRTFCommandHandler(
        IBaseReadRepository<QuestionaireModel> questionaireReadRepository)
    {
        _questionaireReadRepository = questionaireReadRepository;
    }

    public async Task<string?> Handle(ExportQuestionaireToRTFCommand request, CancellationToken cancellationToken)
    {
        var questionaire = await _questionaireReadRepository.FindByIdAsync(request.QuestionaireId, true, cancellationToken);
        if (questionaire == null)
        {
            return null;
        }

        return ExportToRTF(questionaire);
    }

    private static string ExportToRTF(QuestionaireModel questionaire)
    {
        var rtfBuilder = new RTFDocumentBuilder();

        AddLegendTable(rtfBuilder, questionaire.StatementSets);
        AddStatementTable(rtfBuilder, questionaire.StatementSets);

        return rtfBuilder.Build();
    }

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

    private static void AddStatementSetHeaderRow(RTFTableBuilder tableBuilder, int statementCount)
    {
        var headerRow = Enumerable
            .Range(1, statementCount)
            .Select(i => MakeRTFBold($"Statement {i}"))
            .Concat([MakeRTFBold("Response")])
            .ToArray();

        tableBuilder.AddRow(headerRow);
    }

    private static int GetMaxStatementCount(IEnumerable<StatementSetModel> statementSets)
    {
        return statementSets.Max(statementSet => statementSet.Statements.Count);
    }

    private static string MakeRTFBold(string text)
    {
        return $@"\b {text} \b0";
    }
}
