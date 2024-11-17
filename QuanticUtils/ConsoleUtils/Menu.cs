namespace QuanticUtils.ConsoleUtils;

public class Menu()
{
    private List<(string, Action)> Options { get; set; } = [];

    public void Display()
    {
        var selectedIndex = 0;
        var isExit = false;
        while (!isExit)
        {
            for (var i = 0; i < Options.Count; i++)
            {
                var stringOption = selectedIndex == i
                    ? $"> {Options[i].Item1}"
                    : $"* {Options[i].Item1}";
                Console.WriteLine(stringOption);
            }

            var key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (selectedIndex == 0)
                    {
                        ClearLines(Options.Count);
                        break;
                    }

                    ClearLines(Options.Count);
                    selectedIndex--;
                    break;
                case ConsoleKey.DownArrow:
                    if (selectedIndex == Options.Count - 1)
                    {
                        ClearLines(Options.Count);
                        break;
                    }

                    ClearLines(Options.Count);
                    selectedIndex++;
                    break;
                case ConsoleKey.Enter:
                    ClearLines(Options.Count);
                    Options[selectedIndex].Item2();
                    isExit = true;
                    break;
            }
        }
    }


    private static void ClearLines(int count)
    {
        var currentLineCursor = Console.CursorTop;
        for (var i = 0; i < count; i++)
        {
            Console.SetCursorPosition(0, currentLineCursor - i - 1);
            Console.Write(new string(' ', Console.WindowWidth));
        }

        Console.SetCursorPosition(0, currentLineCursor - count);
    }

    public void AddOption(string optionLabel, Action action) =>
        Options.Add((optionLabel, action));
}