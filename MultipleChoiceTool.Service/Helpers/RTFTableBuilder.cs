using System.Text;

namespace MultipleChoiceTool.Service.Helpers;

/// <summary>
/// Helper class to build RTF (Rich Text Format) tables.
/// </summary>
internal class RTFTableBuilder
{
    private const int CellWidth = 2000;
    
    private readonly List<string[]> _rows;

    /// <summary>
    /// Initializes a new instance of the <see cref="RTFTableBuilder"/> class.
    /// </summary>
    public RTFTableBuilder()
    {
        _rows = [];
    }

    /// <summary>
    /// Adds a row to the RTF table.
    /// </summary>
    /// <param name="rowValues">The values of the row cells.</param>
    /// <returns>The current instance of <see cref="RTFTableBuilder"/>.</returns>
    public RTFTableBuilder AddRow(params string[] rowValues)
    {
        _rows.Add(rowValues);
        return this;
    }

    /// <summary>
    /// Builds the RTF table as a string.
    /// </summary>
    /// <returns>The RTF table as a string.</returns>
    public string Build()
    {
        var rtf = new StringBuilder();

        foreach (var row in _rows)
        {
            rtf.Append(@"\trowd");
            for (int i = 0; i < row.Length; i++)
            {
                rtf.Append(BuildBorderRtf());
                rtf.Append($@"\cellx{(i + 1) * CellWidth} " + row[i] + @" \cell");
            }
            rtf.Append(@"\row");
        }

        return rtf.ToString();
    }

    /// <summary>
    /// Builds the RTF string for cell borders.
    /// </summary>
    /// <returns>The RTF string for cell borders.</returns>
    private static string BuildBorderRtf()
    {
        return @"\clbrdrt\brdrs\brdrw10\brdrcf1" + // Top border
               @"\clbrdrl\brdrs\brdrw10\brdrcf1" + // Left border
               @"\clbrdrb\brdrs\brdrw10\brdrcf1" + // Bottom border
               @"\clbrdrr\brdrs\brdrw10\brdrcf1";  // Right border
    }
}
