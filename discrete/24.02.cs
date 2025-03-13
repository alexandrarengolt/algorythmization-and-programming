using System;
using System.Collections.Generic;
using System.Linq;

public class BridgesSearch
{
    static int time;

    public static List<Tuple<int, int, int>> FindBridges(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        bool[] visited = new bool[n];
        int[] enter = new int[n];
        int[] least = new int[n];
        time = 0;
        List<Tuple<int, int, int>> bridges = new List<Tuple<int, int, int>>();

        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                Dfs (i, -1, matrix, visited, enter, least, bridges);
            }
        }

        return bridges;
    }

    private static void Dfs(int v, int parent, int[,] matrix, bool[] visited, int[] enter, int[] least, List<Tuple<int, int, int>> bridges)
    {
        visited[v] = true;
        enter[v] = least[v] = time++;

        for (int n = 0; n < matrix.GetLength(0); n++)
        {
            if (matrix[v, n] != 0)
            {
                if (!visited[n])
                {
                    Dfs(n, v, matrix, visited, enter, least, bridges);
                    least[v] = Math.Min(least[v], least[n]);
                    if (least[n] > enter[v])
                    {
                        bridges.Add(Tuple.Create(matrix[v, n], v, n));
                    }
                }
                else if (n != parent)
                {
                    least[v] = Math.Min(least[v], enter[n]);
                }
            }
        }
    }

    public static void Main(string[] args)
    {
        int[,] matrix = {
            { 0, 10, 2, 0, 0, 0, 0, 0 },
            { 10, 0, 14, 0, 0, 5, 0, 4 },
            { 2, 14, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 8, 0, 1, 0 },
            { 0, 0, 0, 8, 0, 28, 0, 0 },
            { 0, 5, 0, 0, 28, 0, 4, 0 },
            { 0, 0, 0, 1, 0, 4, 0, 0 },
            { 0, 4, 0, 0, 0, 0, 0, 0 }
        };

        List<Tuple<int, int, int>> bridges = FindBridges(matrix);

        Console.WriteLine("Мосты и их веса:");
        foreach (var bridge in bridges)
        {
            Console.WriteLine($"Ребро ({bridge.Item2}, {bridge.Item3}), Вес: {bridge.Item1}");
        }
        Console.WriteLine($"Число мостов = {bridges.Count}");
    }
}
