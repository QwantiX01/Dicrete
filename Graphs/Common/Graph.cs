using QuanticUtils.ConsoleUtils;

namespace Graphs.Common;

public class Graph
{
    private Dictionary<int, List<int>> adjacencyList = [];
    public int Edges { get; set; }
    public int Vertexes { get; set; }

    public bool Contains(int value)
        => adjacencyList.ContainsKey(value);

    public void AddVertex(int value)
    {
        if (Contains(value))
            return;
        adjacencyList.Add(value, []);
        Vertexes++;
    }

    public void AddEdge(int from, int to)
    {
        if (!adjacencyList.TryGetValue(from, out var value)) return;
        value.Add(to);
        Edges++;
    }

    public void PrintGraph()
    {
        foreach (var vertex in adjacencyList)
        {
            Console.Write(vertex.Key + ": ");
            foreach (var edge in vertex.Value)
            {
                Console.Write(edge + " ");
            }

            Console.WriteLine();
        }
    }

    public void DfsDebugRecursive(int value)
    {
        var result = new List<List<string>> { new() { "Вершина", "DFS-Номер", "Стек викликів" } };

        var visited = new HashSet<int>();
        var dfsNumbers = new Dictionary<int, int>();
        var dfsCounter = 1;
        var callStack = new Stack<int>();

        void DfsHelper(int vertex)
        {
            visited.Add(vertex);
            dfsNumbers[vertex] = dfsCounter++;
            callStack.Push(vertex);

            result.Add([
                vertex.ToString(),
                dfsNumbers[vertex].ToString(),
                string.Join(" -> ", callStack.Reverse())
            ]);

            foreach (var neighbor in adjacencyList[vertex])
            {
                if (!visited.Contains(neighbor))
                {
                    DfsHelper(neighbor);
                }
            }

            callStack.Pop();
            result.Add([
                "",
                "",
                string.Join(" -> ", callStack.Reverse())
            ]);
        }

        DfsHelper(value);
        Output.PrintTable(result);
    }

    public void DfsDebug(int value)
    {
        var result = new List<List<string>>();
        result.Add(["Вершина", "DFS-Номер", "Вміст стеку"]);

        var visited = new HashSet<int>();
        var dfsNumbers = new Dictionary<int, int>();
        var skeleton = new Stack<(int, List<int>)>();

        skeleton.Push((value, adjacencyList[value]));
        visited.Add(value);
        dfsNumbers.Add(value, 1);

        result.Add([
            dfsNumbers.First().Key.ToString(), (dfsNumbers.Last().Value).ToString(),
            string.Join(",", skeleton.Select(x => x.Item1.ToString()))
        ]);

        do
        {
            if (skeleton.Count == 0)
                break;
            if (skeleton.Peek().Item2.All(x => visited.Contains(x)))
            {
                skeleton.Pop();
                result.Add([
                    "", "", string.Join(",", skeleton.Select(x => x.Item1.ToString()))
                ]);
            }
            else
            {
                var firstAdjacency =
                    adjacencyList.First(x =>
                        !visited.Contains(x.Key) && skeleton.Peek().Item2.Contains(x.Key));

                visited.Add(firstAdjacency.Key);
                skeleton.Push((firstAdjacency.Key, firstAdjacency.Value));
                dfsNumbers.Add(firstAdjacency.Key, dfsNumbers.Last().Value + 1);

                result.Add([
                    firstAdjacency.Key.ToString(), (dfsNumbers.Last().Value).ToString(),
                    string.Join(",", skeleton.Select(x => x.Item1.ToString()))
                ]);
            }
        } while (true);

        Output.PrintTable(result);
    }

    public Dictionary<int, int> Dfs(int value)
    {
        var visited = new HashSet<int>();
        var dfsNumbers = new Dictionary<int, int>();
        var skeleton = new Stack<(int, List<int>)>();

        skeleton.Push((value, adjacencyList[value]));
        visited.Add(value);
        dfsNumbers.Add(value, 1);

        do
        {
            if (skeleton.Count == 0)
                break;
            if (skeleton.Peek().Item2.All(x => visited.Contains(x)))
                skeleton.Pop();
            else
            {
                var firstAdjacency =
                    adjacencyList.First(x =>
                        !visited.Contains(x.Key) && skeleton.Peek().Item2.Contains(x.Key));

                visited.Add(firstAdjacency.Key);
                skeleton.Push((firstAdjacency.Key, firstAdjacency.Value));
                dfsNumbers.Add(firstAdjacency.Key, dfsNumbers.Last().Value + 1);
            }
        } while (true);

        return dfsNumbers;
    }

    public Dictionary<int, int> DfsRecursive(int value)
    {
        var visited = new HashSet<int>();
        var dfsNumbers = new Dictionary<int, int>();
        int dfsCounter = 1;

        void DfsHelper(int vertex)
        {
            visited.Add(vertex);
            dfsNumbers[vertex] = dfsCounter++;

            foreach (var neighbor in adjacencyList[vertex])
            {
                if (!visited.Contains(neighbor))
                {
                    DfsHelper(neighbor);
                }
            }
        }

        DfsHelper(value);

        return dfsNumbers;
    }

    public Dictionary<int, int> Bfs(int value)
    {
        var visited = new HashSet<int>();
        var bfsNumbers = new Dictionary<int, int>();
        var bfsCounter = 1;
        var skeleton = new Queue<(int, List<int>)>();

        bfsNumbers[value] = bfsCounter;
        skeleton.Enqueue((value, adjacencyList[value]));
        do
        {
            if (skeleton.Count == 0)
                return bfsNumbers;

            if (skeleton.Peek().Item2.All(x => visited.Contains(x)))
                skeleton.Dequeue();

            else
            {
                var firstAdjacency =
                    adjacencyList.First(x => !visited.Contains(x.Key) && skeleton.Peek().Item2.Contains(x.Key));
                visited.Add(firstAdjacency.Key);
                skeleton.Enqueue((firstAdjacency.Key, firstAdjacency.Value));
                bfsNumbers[firstAdjacency.Key] = ++bfsCounter;
            }
        } while (true);
    }

    public void BfsDebug(int value)
    {
        var result = new List<List<string>> { new() { "Вершина", "BFS-Номер", "Вміст черги" } };
        var visited = new HashSet<int>();
        var bfsNumbers = new Dictionary<int, int>();
        var bfsCounter = 1;
        var skeleton = new Queue<(int, List<int>)>();

        bfsNumbers[value] = bfsCounter;
        skeleton.Enqueue((value, adjacencyList[value]));
        visited.Add(value);
        
        result.Add([
            bfsNumbers.First().Key.ToString(), bfsNumbers.First().Value.ToString(),
            string.Join(",", skeleton.Select(x => x.Item1.ToString()))
        ]);

        do
        {
            if (skeleton.Count == 0)
            {
                Output.PrintTable(result);
                return;
            }

            if (skeleton.Peek().Item2.All(x => visited.Contains(x)))
            {
                skeleton.Dequeue();
                result.Add([
                    " ", " ",
                    string.Join(",", skeleton.Select(x => x.Item1.ToString()))
                ]);
            }

            else
            {
                var firstAdjacency =
                    adjacencyList.First(x => !visited.Contains(x.Key) && skeleton.Peek().Item2.Contains(x.Key));
                visited.Add(firstAdjacency.Key);
                skeleton.Enqueue((firstAdjacency.Key, firstAdjacency.Value));
                bfsNumbers[firstAdjacency.Key] = ++bfsCounter;

                result.Add([
                    firstAdjacency.Key.ToString(), bfsNumbers.Last().Value.ToString(),
                    string.Join(",", skeleton.Select(x => x.Item1.ToString()))
                ]);
            }
        } while (true);
    }
}