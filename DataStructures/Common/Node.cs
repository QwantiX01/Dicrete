namespace DataStructures.Common;

public class Node<T>(T value, Node<T>? nextNode)
{
    public T Value { get; set; } = value;
    public Node<T>? NextNode { get; set; } = nextNode;
}