using System.Text;

namespace MultipleChoiceTool.Service.Helpers;

internal class RTFDocumentBuilder
{
    private readonly List<RTFTableBuilder> _tables;

    public RTFDocumentBuilder()
    {
        _tables = [];
    }

    public RTFTableBuilder AddTable()
    {
        var tableBuilder = new RTFTableBuilder();
        _tables.Add(tableBuilder);
        return tableBuilder;
    }

    public string Build()
    {
        var rtf = new StringBuilder();

        rtf.Append(@"{\rtf1\ansi\deff0");
        foreach (var table in _tables)
        {
            rtf.Append(table.Build());
            rtf.Append(@"\par\par");
        }
        rtf.Append("}");
        
        return rtf.ToString();
    }
}
