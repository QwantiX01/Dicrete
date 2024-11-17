// See https://aka.ms/new-console-template for more information

using Graphs.Common;
using QuanticUtils.ConsoleUtils;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var graph = new Graph();
for (var i = 1; i <= 8; i++)
    graph.AddVertex(i);

graph.AddEdge(1, 2);
graph.AddEdge(1, 3);
graph.AddEdge(1, 4);
graph.AddEdge(1, 7);
graph.AddEdge(1, 8);
graph.AddEdge(2, 7);
graph.AddEdge(2, 8);
graph.AddEdge(4, 5);
graph.AddEdge(5, 6);
graph.AddEdge(7, 8);

var bfs = graph.Bfs(1);
foreach (var bf in bfs)
{
    Console.WriteLine($"{bf.Key}, {bf.Value}");
}

var menu = new Menu();

menu.AddOption("Рекурсивний пошук вглиб", () => { graph.DfsDebugRecursive(1); });
menu.AddOption("Не рекурсивний пошук вглиб", () => { graph.DfsDebug(1); });
menu.AddOption("Пошук вшир", () => { graph.BfsDebug(1); });

menu.Display();