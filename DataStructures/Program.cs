using DataStructures.Common;
using QuanticUtils.ConsoleUtils;

namespace DataStructures;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var menu = new Menu();
        menu.AddOption("Double linked list", MyListTest);
        menu.AddOption("Stack", MyStackTest);
        menu.AddOption("Queue", MyQueueTest);
        menu.AddOption("Вийти", () => Environment.Exit(0));

        while (true)
        {
            menu.Display();
        }
    }

    static void MyListTest()
{
    var list = new MyLinkedList<int>();
    var menu = new Menu();
    var isDone = false;

    menu.AddOption("Додати на початок", () =>
    {
        Console.Write("Введіть число: ");
        var value = (int)Input.GetNumber();
        list.AddBegin(value);
        Console.WriteLine("Додано на початок.");
        list.Display();
    });

    menu.AddOption("Додати в кінець", () =>
    {
        Console.Write("Введіть число: ");
        var value = (int)Input.GetNumber();
        list.AddLast(value);
        Console.WriteLine("Додано в кінець.");
        list.Display();
    });

    menu.AddOption("Додати після певного значення", () =>
    {
        Console.Write("Введіть значення для пошуку: ");
        var findValue = (int)Input.GetNumber();

        if (!list.Contains(findValue)) // Check if the value exists in the list
        {
            Console.WriteLine($"Значення {findValue} не знайдено в списку.");
            return;
        }

        Console.Write("Введіть нове значення для додавання: ");
        var newValue = (int)Input.GetNumber();

        list.AddMid(findValue, newValue);
        Console.WriteLine($"Значення {newValue} додано після {findValue}.");
        list.Display();
    });

    menu.AddOption("Видалити з початку", () =>
    {
        if (list.IsEmpty()) // Check if the list is empty
        {
            Console.WriteLine("Список порожній. Немає елементів для видалення.");
            return;
        }
        
        list.RemoveBegin();
        Console.WriteLine("Перший елемент видалено.");
        list.Display();
    });

    menu.AddOption("Видалити з кінця", () =>
    {
        if (list.IsEmpty()) // Check if the list is empty
        {
            Console.WriteLine("Список порожній. Немає елементів для видалення.");
            return;
        }

        list.RemoveLast();
        Console.WriteLine("Останній елемент видалено.");
        list.Display();
    });

    menu.AddOption("Видалити певне значення", () =>
    {
        Console.Write("Введіть значення для видалення: ");
        var removeValue = (int)Input.GetNumber();

        if (!list.Contains(removeValue)) // Check if the value exists in the list
        {
            Console.WriteLine($"Значення {removeValue} не знайдено в списку.");
            return;
        }

        list.DelMid(removeValue);
        Console.WriteLine($"Значення {removeValue} видалено.");
        list.Display();
    });

    menu.AddOption("Відобразити список", () =>
    {
        if (list.IsEmpty())
        {
            Console.WriteLine("Список порожній.");
        }
        else
        {
            Console.WriteLine("Поточний список:");
            list.Display();
        }
    });

    menu.AddOption("Відобразити список у зворотному порядку", () =>
    {
        if (list.IsEmpty())
        {
            Console.WriteLine("Список порожній.");
        }
        else
        {
            Console.WriteLine("Поточний список у зворотному порядку:");
            list.DisplayReverse();
        }
    });

    menu.AddOption("Вихід", () => isDone = true);

    while (!isDone)
    {
        menu.Display();
        Console.WriteLine('\v');
    }
}


    static void MyStackTest()
    {
        var stack = new MyStack<int>();
        var menu = new Menu();

        menu.AddOption("Додати елемент (Push)", () =>
        {
            Console.Write("Введіть число для додавання: ");
            var value = (int)Input.GetNumber();
            stack.Push(value);
            Console.WriteLine("Елемент додано.");
            stack.Display();
        });

        menu.AddOption("Видалити верхній елемент (Pop)", () =>
        {
            try
            {
                var value = stack.Pop();
                Console.WriteLine($"Елемент {value} видалено.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            stack.Display();
        });

        menu.AddOption("Показати верхній елемент (Peek)", () =>
        {
            try
            {
                int value = stack.Peek();
                Console.WriteLine($"Верхній елемент: {value}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        });

        menu.AddOption("Показати всі елементи", () =>
        {
            Console.WriteLine("Поточний стек:");
            stack.Display();
        });

        menu.AddOption("Порахувати елементи (Count)", () =>
        {
            var count = stack.Count();
            Console.WriteLine($"Кількість елементів у стеку: {count}");
        });

        menu.AddOption("Вихід", () => Environment.Exit(0));

        while (true)
        {
            menu.Display();
            Console.WriteLine('\v');
        }
    }

    static void MyQueueTest()
    {
        var queue = new MyQueue<int>();
        var menu = new Menu();

        menu.AddOption("Додати елемент у чергу (Enqueue)", () =>
        {
            Console.Write("Введіть число для додавання: ");
            int value = (int)Input.GetNumber();
            queue.Enqueue(value);
            Console.WriteLine("Елемент додано в чергу.");
            queue.Display();
        });

        menu.AddOption("Видалити елемент із черги (Dequeue)", () =>
        {
            try
            {
                int value = queue.Dequeue();
                Console.WriteLine($"Елемент {value} видалено з черги.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            queue.Display();
        });

        menu.AddOption("Переглянути перший елемент (Peek)", () =>
        {
            try
            {
                int value = queue.Peek();
                Console.WriteLine($"Перший елемент у черзі: {value}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        });

        menu.AddOption("Перевірити, чи черга порожня (IsEmpty)", () =>
        {
            bool isEmpty = queue.IsEmpty();
            Console.WriteLine(isEmpty ? "Черга порожня" : "Черга не порожня");
        });

        menu.AddOption("Показати всі елементи в черзі", () =>
        {
            Console.WriteLine("Поточна черга:");
            queue.Display();
        });

        menu.AddOption("Порахувати елементи в черзі (Count)", () =>
        {
            long count = queue.Count();
            Console.WriteLine($"Кількість елементів у черзі: {count}");
        });

        menu.AddOption("Очистити чергу (Clear)", () =>
        {
            queue.Clear();
            Console.WriteLine("Чергу очищено.");
            queue.Display();
        });

        menu.AddOption("Вихід", () => Environment.Exit(0));

        while (true)
        {
            menu.Display();
            Console.WriteLine('\v');
        }
    }
}