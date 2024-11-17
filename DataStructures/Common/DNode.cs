namespace DataStructures.Common;

public class DNode<T>(DNode<T>? previousNode, T value, DNode<T>? nextNode)
{
    public DNode<T>? PreviousNode { get; set; } = previousNode;
    public T Value { get; set; } = value;
    public DNode<T>? NextNode { get; set; } = nextNode;
}