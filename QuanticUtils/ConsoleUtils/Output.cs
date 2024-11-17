using System.Text;

namespace QuanticUtils.ConsoleUtils;

public static class Output
{
    public static void PrintTable(List<List<string>> data)
    {
        var hBorder = '─';
        var vBorder = '│';

        var colLens = new List<int>(data.Count);
        var maxColLen = data.Max(x => x.Count);

        for (var col = 0; col < maxColLen; col++)
        {
            var max = data
                .Select((_, row) => data
                    .ElementAtOrDefault(row)
                    ?.ElementAtOrDefault(col)
                    ?.Length ?? 0)
                .Aggregate(0, (current, elLen) => elLen > current ? elLen : current);
            colLens.Add(max);
        }

        var a = new string[data.Count * 2 + 1];

        var rowCount = 0;
        for (var i = 0; i < a.Length; i++)
            if (i % 2 == 1)
            {
                var row = new StringBuilder(vBorder.ToString());
                for (var j = 0; j < maxColLen; j++)
                {
                    var value = data.ElementAtOrDefault(rowCount)?.ElementAtOrDefault(j) ?? "";
                    var whiteSpacesCount = (colLens[j] - value.Length) / 2;
                    var whiteSpaces = new string(Enumerable.Repeat(' ', whiteSpacesCount).ToArray());
                    var formatedValue = $"{whiteSpaces}{value}{whiteSpaces}";
                    if (formatedValue.Length != colLens[j])
                        formatedValue += " ";
                    row.Append($"{formatedValue}{vBorder}");
                }

                rowCount++;
                a[i] = row.ToString();
            }
            else
            {
                var row = new StringBuilder();
                if (i == 0)
                {
                    row.Append('╭');
                    foreach (var value in colLens)
                        row.Append($"{new string(Enumerable.Repeat(hBorder, value).ToArray())}┬");
                    row[^1] = '╮';
                }
                else if (a.Length - 1 == i)
                {
                    row.Append('╰');
                    foreach (var value in colLens)
                        row.Append($"{new string(Enumerable.Repeat(hBorder, value).ToArray())}┴");
                    row[^1] = '╯';
                }
                else
                {
                    row.Append('├');
                    foreach (var value in colLens)
                        row.Append($"{new string(Enumerable.Repeat(hBorder, value).ToArray())}┼");
                    row[^1] = '┤';
                }

                a[i] = row.ToString();
            }

        Console.WriteLine(string.Join('\n', a));
    }
}