using System;
using System.Collections.Generic;

class Program
{
    static int FordFulkerson(int[,] graph, int source, int sink)
    {
        int n = graph.GetLength(0);
        int[,] residual = new int[n, n];
        Array.Copy(graph, residual, graph.Length);
        int[] parent = new int[n];
        int maxFlow = 0;

        while (true)
        {
            int flow = dfs(residual, source, sink, parent);
            if (flow == 0)
                break;

            int v = sink;
            while (v != source)
            {
                int u = parent[v];
                residual[u, v] -= flow;
                residual[v, u] += flow;
                v = u;
            }

            maxFlow += flow;
        }

        return maxFlow;
    }

    static int dfs(int[,] residual, int source, int sink, int[] parent)
    {
        int n = residual.GetLength(0);
        bool[] visited = new bool[n];
        Stack<(int, int)> stack = new Stack<(int, int)>();
        stack.Push((source, int.MaxValue));
        visited[source] = true;
        parent[source] = -1;

        while (stack.Count > 0)
        {
            var (u, flow) = stack.Pop();

            for (int v = 0; v < n; v++)
            {
                if (!visited[v] && residual[u, v] > 0)
                {
                    visited[v] = true;
                    parent[v] = u;
                    int newFlow = Math.Min(flow, residual[u, v]);
                    if (v == sink)
                        return newFlow;
                    stack.Push((v, newFlow));
                }
            }
        }

        return 0;
    }

    static void Main()
    {
        int[,] graph = new int[,]
        {
            { 0, 76, 47, 0, 0, 41 },
            { 0, 0, 0, 0, 44, 56 },
            { 0, 0, 0, 25, 15, 0 },
            { 0, 35, 0, 0, 13, 29 },
            { 0, 0, 0, 0, 0, 50 },
            { 0, 0, 0, 0, 0, 0 }
        };

        int source = 0;
        int sink = 5;

        int maxFlow = FordFulkerson(graph, source, sink);
        Console.WriteLine($"Максимальный поток: {maxFlow}");
    }
}

