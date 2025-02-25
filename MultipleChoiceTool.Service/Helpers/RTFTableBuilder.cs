using System.Text;

namespace MultipleChoiceTool.Service.Helpers;

internal class RTFTableBuilder
{
    private const int CellWidth = 2000;
    
    private readonly List<string[]> _rows;

    public RTFTableBuilder()
    {
        _rows = [];
    }

    public RTFTableBuilder AddRow(params string[] rowValues)
    {
        _rows.Add(rowValues);
        return this;
    }

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

    private static string BuildBorderRtf()
    {
        return @"\clbrdrt\brdrs\brdrw10\brdrcf1" + // Top border
               @"\clbrdrl\brdrs\brdrw10\brdrcf1" + // Left border
               @"\clbrdrb\brdrs\brdrw10\brdrcf1" + // Bottom border
               @"\clbrdrr\brdrs\brdrw10\brdrcf1";  // Right border
    }
}
