using System.Text;

namespace MultipleChoiceTool.Service.Helpers;

/// <summary>
/// Helper class to build RTF (Rich Text Format) documents.
/// </summary>
internal class RTFDocumentBuilder
{
    private readonly List<RTFTableBuilder> _tables;

    /// <summary>
    /// Initializes a new instance of the <see cref="RTFDocumentBuilder"/> class.
    /// </summary>
    public RTFDocumentBuilder()
    {
        _tables = [];
    }

    /// <summary>
    /// Adds a new table to the RTF document.
    /// </summary>
    /// <returns>A new instance of <see cref="RTFTableBuilder"/>.</returns>
    public RTFTableBuilder AddTable()
    {
        var tableBuilder = new RTFTableBuilder();
        _tables.Add(tableBuilder);
        return tableBuilder;
    }

    /// <summary>
    /// Builds the RTF document as a string.
    /// </summary>
    /// <returns>The RTF document as a string.</returns>
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
