using DataStructures.Common;

public class MyStack<T>
{
    private Node<T>? Head;

    public long Count()
    {
        if (Head is null) return 0;
        var currentNode = Head;
        var i = 0L;
        while (currentNode != null)
        {
            currentNode = currentNode.NextNode;
            i++;
        }
        return i;
    }

    public void Push(T value)
    {
        var newNode = new Node<T>(value, Head);
        Head = newNode;
    }

    public T? Pop()
    {
        if (Head is null) throw new InvalidOperationException("Stack is empty");
        
        var value = Head.Value;
        Head = Head.NextNode;
        return value;
    }

    public T? Peek()
    {
        if (Head is null) throw new InvalidOperationException("Stack is empty");
        return Head.Value;
    }

    public void Display()
    {
        if (Head is null) return;
        var currentNode = Head;
        while (currentNode != null)
        {
            Console.Write($"{currentNode.Value?.ToString()} ");
            currentNode = currentNode.NextNode;
        }
        Console.WriteLine();
    }
}