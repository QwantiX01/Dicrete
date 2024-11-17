namespace DataStructures.Common;

public interface IMyLinkedList<T>
{
    public DNode<T> Head { get; set; }

    public void AddLast(T value);
    public void AddBegin(T value);
    public void RemoveLast();
    public void RemoveBegin();
    public int? Search(T value);
}