using System;
using System.Data;
using QuanticUtils.ConsoleUtils;

namespace DataStructures
{
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var menu = new Menu();
            menu.AddOption("Expression Transformations", TransformationsMenu);
            menu.AddOption("Вийти", () => Environment.Exit(0));

            while (true)
            {
                menu.Display();
            }
        }

        static void TransformationsMenu()
        {
            var convertor = new Convertor.Convertor();
            var menu = new Menu();
            var isDone = false;

            menu.AddOption("Infix to Postfix", () =>
            {
                Console.Write("Введіть інфіксну вираз: ");
                var infix = Console.ReadLine();
                var postfix = convertor.InfixToPostfix(infix);
                Console.WriteLine("Постфіксна форма: " + postfix);
                Console.WriteLine("Рузультат: " + convertor.EvaluatePostfix(postfix));
            });

            menu.AddOption("Infix to Prefix", () =>
            {
                Console.Write("Введіть інфіксну вираз: ");
                var infix = Console.ReadLine();
                var prefix = convertor.InfixToPrefix(infix);
                Console.WriteLine("Префіксна форма: " + prefix);
                Console.WriteLine("Рузультат: " + convertor.EvaluatePrefix(prefix));
            });

            menu.AddOption("Postfix to Infix", () =>
            {
                Console.Write("Введіть постфіксну вираз: ");
                var postfix = Console.ReadLine();
                var infix = convertor.PostfixToInfix(postfix);
                Console.WriteLine("Інфіксна форма: " + infix);
                Console.WriteLine("Рузультат: " + convertor.EvaluateInfix(infix));
            });

            menu.AddOption("Prefix to Infix", () =>
            {
                Console.Write("Введіть префіксну вираз: ");
                var prefix = Console.ReadLine();
                var infix = convertor.PrefixToInfix(prefix);
                Console.WriteLine("Інфіксна форма: " + infix);
                Console.WriteLine("Рузультат: " + convertor.EvaluateInfix(infix));
            });

            menu.AddOption("Вихід", () => isDone = true);

            while (!isDone)
            {
                menu.Display();
                Console.WriteLine('\v');
            }
        }
    }
}