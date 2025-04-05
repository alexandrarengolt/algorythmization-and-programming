using System;
using System.Linq;
using System.Collections.Generic;

public class  DijkstraAlgorithm
{
    public static void Main(string[] args)
    {
        Console.Write("Введите начальную вершину - ");
        int start = int.Parse(Console.ReadLine()) - 1;

        Console.Write("Введите конечную вершину - ");
        int end = int.Parse(Console.ReadLine()) - 1;

        int[,] matrix = {
            { 0, 5, 0, 0, 2, 4 },
            { 5, 0, 12, 0, 0, 1 },
            { 0, 12, 0, 9, 0, 3 },
            { 0, 0, 9, 0, 7, 10 },
            { 2, 0, 0, 7, 0, 8 },
            { 4, 1, 3, 10, 8, 0 }
        };

        int size = matrix.GetLength(0);
        int zero = matrix.Cast<int>().Max() * 1000;
        List<int> visitedEdges = new List<int> { start };
        int currentEdge = start;
        int[] length = new int[size];
        Array.Copy(matrix.GetRow(start), length, size);
        int localMin = matrix.GetRow(currentEdge).Where(x => x != 0).Min();

        for (int k = 0; k < size; k++)
        {
            if (length[k] == 0 && k != start)
            {
                length[k] = zero;
            }
        }

        while (currentEdge != end)
        {
            for (int i = 0; i < size; i++)
            {
                if (i == currentEdge && visitedEdges.Count != size)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (!visitedEdges.Contains(j) && i != j && matrix[i, j] != 0)
                        {
                            length[j] = Math.Min(length[j], localMin + matrix[i, j]);
                        }
                    }
                    localMin = length.Where((x, index) => x != 0 && !visitedEdges.Contains(index)).Min();
                    currentEdge = Array.IndexOf(length, localMin);
                    visitedEdges.Add(currentEdge);
                }
            }
        }

        Console.WriteLine($"Длина маршрута = {length[currentEdge]}");

        List<int> previousEdges = new List<int> { currentEdge };

        while (currentEdge != start)
        {
            int[] column = matrix.GetColumn(currentEdge);
            for (int t = 0; t < size; t++)
            {
                if (column[t] + length [t] == length[currentEdge])
                {
                    currentEdge= t;
                }
            }
            previousEdges.Add(currentEdge);
        }

        previousEdges.Reverse();
        List<int> rightEdges = previousEdges.Select(el => el + 1).ToList();

        Console.Write("Маршрут: ");
        Console.WriteLine(string.Join(", ", rightEdges));
    }
}

public static class ArrayExtensions
{
    public static int[] GetRow(this int[,] matrix, int rowNumber)
    {
        return Enumerable.Range(0, matrix.GetLength(1))
                .Select(x => matrix[rowNumber, x])
                .ToArray();
    }

    public static int[] GetColumn(this int[,] matrix, int columnNumber)
    {
        return Enumerable.Range(0, matrix.GetLength(0))
                .Select(x => matrix[x, columnNumber])
                .ToArray();
    }
}
