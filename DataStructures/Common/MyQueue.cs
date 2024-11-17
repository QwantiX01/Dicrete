namespace DataStructures.Common;

public class MyQueue<T>
{
    private Node<T>? Head;
    private Node<T>? Tail;

    public long Count()
    {
        if (Head is null) return 0;
        
        var currentNode = Head;
        var count = 0L;
        while (currentNode != null)
        {
            currentNode = currentNode.NextNode;
            count++;
        }
        return count;
    }

    public void Enqueue(T value)
    {
        var newNode = new Node<T>(value, null);
        
        if (Head is null)
        {
            Head = newNode;
            Tail = newNode;
            return;
        }

        Tail!.NextNode = newNode;
        Tail = newNode;
    }

    public T Dequeue()
    {
        if (Head is null)
            throw new InvalidOperationException("Queue is empty");

        var value = Head.Value;
        Head = Head.NextNode;

        if (Head is null)
            Tail = null;

        return value;
    }

    public T Peek()
    {
        if (Head is null)
            throw new InvalidOperationException("Queue is empty");

        return Head.Value;
    }

    public bool IsEmpty()
    {
        return Head is null;
    }

    public void Display()
    {
        if (Head is null)
        {
            Console.WriteLine("Queue is empty");
            return;
        }

        var currentNode = Head;
        while (currentNode != null)
        {
            Console.Write($"{currentNode.Value?.ToString()} ");
            currentNode = currentNode.NextNode;
        }
        Console.WriteLine();
    }

    public void Clear()
    {
        Head = null;
        Tail = null;
    }
}