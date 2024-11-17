using System.Text;
using QuanticUtils.ConsoleUtils;
using static Combinatorics.Comb.Comb;

namespace Combinatorics;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        var menu = new Menu();
        menu.AddOption("Частина 1", First);
        menu.AddOption("Частина 2", Second);


        while (true)
        {
            menu.Display();
        }
    }

    static void First()
    {
        Console.WriteLine("Введіть n");
        var n = (int)Input.GetNumber();
        Console.WriteLine("Введіть k");
        var k = (int)Input.GetNumber();
        var sb = new StringBuilder();
        sb.Append($"Кількість розміщень без повторень: {A(n, k)}\n");
        sb.Append($"Кількість розміщень з повтореннями: {_A(n, k)}\n");
        sb.Append($"Кількість сполучень без повторень: {C(n, k)}\n");
        sb.Append($"Кількість сполучень з повтореннями: {_C(n, k)}\n");
        sb.Append($"Кількість перестановок: {Factorial(n)}\n");
        Console.WriteLine(sb.ToString());
    }

    static void Second()
    {
        Console.WriteLine("Введіть довжину масиву");
        var n = (int)Input.GetNumber();
        var array = new int[n];
        Console.WriteLine("Введіть масив");
        for (int i = 0; i < n; i++)
        {
            var number = (int)Input.GetNumber();
            array[i] = number;
        }

        for (var i = 0; i < Factorial(array.Length); i++)
        {
            Console.WriteLine(string.Join(" ", array));
            array = GenPerm(array);
        }
    }
}