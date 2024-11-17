namespace DataStructures.Common;

public class MyLinkedList<T> : IMyLinkedList<T>
{
    public DNode<T>? Head { get; set; }
    public DNode<T>? Tail { get; set; } // Added Tail reference

    public T? Last => Tail.Value;
    public T? First => Head.Value;

    public void AddLast(T value)
    {
        var newNode = new DNode<T>(Tail, value, null);

        if (Head is null)
        {
            Head = newNode;
            Tail = newNode;
            return;
        }

        Tail!.NextNode = newNode;
        Tail = newNode;
    }

    public void AddBegin(T value)
    {
        var newNode = new DNode<T>(null, value, Head);

        if (Head is null)
        {
            Head = newNode;
            Tail = newNode;
            return;
        }

        Head.PreviousNode = newNode;
        Head = newNode;
    }

    public void RemoveLast()
    {
        if (Head is null) return;

        if (Head == Tail)
        {
            Head = null;
            Tail = null;
            return;
        }

        Tail = Tail!.PreviousNode;
        Tail!.NextNode = null;
    }

    public void RemoveBegin()
    {
        if (Head is null) return;

        if (Head == Tail)
        {
            Head = null;
            Tail = null;
            return;
        }

        Head = Head.NextNode;
        Head!.PreviousNode = null;
    }

    public int? Search(T value)
    {
        if (Head is null)
            return null;

        var currentNode = Head;
        var index = 0;

        while (currentNode != null)
        {
            if (currentNode.Value!.Equals(value))
                return index;

            currentNode = currentNode.NextNode;
            index++;
        }

        return null;
    }

    public bool IsEmpty()
    {
        return Head == null;
    }

    public bool Contains(T value)
    {
        var current = Head;
        while (current != null)
        {
            if (current.Value!.Equals(value))
            {
                return true;
            }

            current = current.NextNode;
        }

        return false;
    }

    public void Display()
    {
        if (Head is null)
        {
            Console.WriteLine("List is empty");
            return;
        }

        var current = Head;
        while (current != null)
        {
            Console.Write($"{current.Value} ");
            current = current.NextNode;
        }

        Console.WriteLine();
    }

    public void DisplayReverse()
    {
        if (Tail is null)
        {
            Console.WriteLine("List is empty");
            return;
        }

        var current = Tail;
        while (current != null)
        {
            Console.Write($"{current.Value} ");
            current = current.PreviousNode;
        }

        Console.WriteLine();
    }

    public void AddMid(T valueToFind, T newValue)
    {
        if (Head == null) return;

        var current = Head;
        while (current != null)
        {
            if (current.Value!.Equals(valueToFind))
            {
                var newNode = new DNode<T>(current, newValue, current.NextNode);

                if (current.NextNode != null)
                {
                    current.NextNode.PreviousNode = newNode;
                }
                else
                {
                    // If the current node is the Tail, update Tail to new node.
                    Tail = newNode;
                }

                current.NextNode = newNode;
                return;
            }

            current = current.NextNode;
        }
    }

    public void DelMid(T valueToFind)
    {
        if (Head == null) return;

        var current = Head;
        while (current != null)
        {
            if (current.Value!.Equals(valueToFind))
            {
                if (current.PreviousNode != null)
                    current.PreviousNode.NextNode = current.NextNode;
                else
                    Head = current.NextNode;

                if (current.NextNode != null)
                    current.NextNode.PreviousNode = current.PreviousNode;
                else
                    Tail = current.PreviousNode;

                return;
            }

            current = current.NextNode;
        }
    }
}