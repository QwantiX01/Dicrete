using System.Text;
using QuanticUtils.ConsoleUtils;
using static Sorting.Common.Sorting;

namespace Sorting;

public class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;

        Console.WriteLine("Введіть числа масиву (1 2 3 4 ...)");
        var len = (int)Input.GetNumber();
        var numbers = new int[len];
        for (int i = 0; i < len; i++)
        {
            numbers[i] = (int)Input.GetNumber();
        }

        Console.WriteLine("Введіть числа масиву (1 2 3 4 ...)");
        while (true)
        {
            Console.WriteLine("Введіть початковий індекс (початковий: 0)");
            var startIndex = (int)Input.GetNumber();
            Console.WriteLine($"Введіть кінцевий індекс (кінцевий: {numbers.Length - 1})");
            var endIndex = (int)Input.GetNumber() - 1;
            Console.WriteLine("Введіть тип сортування\n" +
                              "1. BubbleSort\n" +
                              "2. InsertionSort\n" +
                              "3. SelectionSort\n");
            var option = Input.GetNumber();
            var sortedArray = option switch
            {
                1 => SortBubble(numbers, startIndex, endIndex),
                2 => SortInsertion(numbers, startIndex, endIndex),
                3 => SortSelection(numbers, startIndex, endIndex),
                _ => numbers.ToArray(),
            };
            var indexes = Enumerable.Range(0, sortedArray.Length).Select(x => x.ToString()).ToList();
            indexes.Insert(0, "Indexes");
            var formatedValue = sortedArray.Select(x => x.ToString()).ToList();
            formatedValue.Insert(0, "Values");
            List<List<string>> tableArray =
            [
                indexes,
                formatedValue,
                ["Min", Min(numbers).ToString()],
                ["Max", Max(numbers).ToString()]
            ];
            Output.PrintTable(tableArray);
        }
    }
}