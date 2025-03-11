using System;
using System.Collections.Generic;
using System.Linq;

//алгоритм Прима

public class Prim
{
    public static void Main(string[] args)
    {
        int[,] matrix = {
            {0, 13, 6, 0, 9, 11},
            {13, 0, 8, 9, 0, 4},
            {6, 8, 0, 33, 11, 0},
            {0, 9, 33, 0, 20, 20},
            {9, 0, 11, 20, 0, 20},
            {11, 4, 0, 20, 20, 0}
        };

        int size = matrix.GetLength(0);
        int first = 0;

        List<int> edges = Enumerable.Range(0, size).ToList();
        List<int> visitedEdges = new List<int> { first };
        edges.Remove(first);

        List<List<int>> availableVertex = new List<List<int>>();
        for (int i = 0; i < size; i++)
        {
            availableVertex.Add(new List<int>());
        }

        int pathLength = 0;
        List<int> minElementsList = new List<int>();

        while (edges.Count > 0)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (visitedEdges.Contains(i) && !visitedEdges.Contains(j))
                    {
                        availableVertex[i].Add(matrix[i, j]);
                    }
                }
            }

            List<int> minWeights = new List<int>();
            List<int> minWeightsIndexes = new List<int>();

            for (int c = 0; c < availableVertex.Count; c++)
            {
                List<int> leftAvailableVertex = availableVertex[c].ToList();
                leftAvailableVertex.Sort();

                foreach (int item in leftAvailableVertex)
                {
                    if (item != 0)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            if (matrix[c, j] == item && !visitedEdges.Contains(j))
                            {
                                minWeights.Add(item);
                                minWeightsIndexes.Add(j); 
                                break;
                            }
                        }
                        break;
                    }
                }
            }

            if (minWeights.Count > 0)
            {
                int minElement = minWeights.Min();
                int minElementIndex = minWeightsIndexes[minWeights.IndexOf(minElement)];

                pathLength += minElement;
                minElementsList.Add(minElement);
                visitedEdges.Add(minElementIndex);
                edges.Remove(minElementIndex);
            }
            else
            {
                Console.WriteLine("Нет доступных ребер.");
                break;
            }

            for (int i = 0; i < size; i++)
            {
                availableVertex[i].Clear();
            }
        }

        Console.WriteLine($"Минимальный вес остовного дерева = {pathLength}");
        Console.WriteLine($"Список минимальных весов ребер:");
        Console.WriteLine(string.Join(", ", minElementsList));
    }
}

public static class MatrixExtensions
{
    public static T[] GetRow<T>(this T[,] matrix, int rowIndex)
    {
        int rowLength = matrix.GetLength(1);
        T[] row = new T[rowLength];
        for (int i = 0; i < rowLength; i++)
        {
            row[i] = matrix[rowIndex, i];
        }
        return row;
    }
}

//алгоритм Крускалла

public class Kruskal
{
    public static void Main(string[] args)
    {
        int[,] matrix = {
            {0, 13, 6, 0, 9, 11},
            {13, 0, 8, 9, 0, 4},
            {6, 8, 0, 33, 11, 0},
            {0, 9, 33, 0, 20, 20},
            {9, 0, 11, 20, 0, 20},
            {11, 4, 0, 20, 20, 0}
        };

        List<int> edges = Enumerable.Range(0, matrix.GetLength(0)).ToList();
        int size = matrix.GetLength(0);
        List<int> visitedEdges = new List<int>();
        int[] maxima = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int max = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                }
            }
            maxima[i] = max;
        }

        int searchOfMinimum = maxima.Max();
        int iMin = 0, jMin = 0;
        int pathLength = 0;

        while (edges.Count != 0)
        {
            if (edges.Count == size)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = i + 1; j < size; j++)
                    {
                        if (matrix[i, j] <= searchOfMinimum && matrix[i, j] != 0)
                        {
                            searchOfMinimum = matrix[i, j];
                            iMin = i;
                            jMin = j;
                        }
                    }
                }
                pathLength += searchOfMinimum;
                matrix[iMin, jMin] = 0;
                edges.Remove(iMin);
                edges.Remove(jMin);
                visitedEdges.Add(iMin);
                visitedEdges.Add(jMin);
                searchOfMinimum = maxima.Max();
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = i + 1; j < size; j++)
                    {
                        if ((visitedEdges.Contains(i) ^ visitedEdges.Contains(j)) && matrix[i, j] <= searchOfMinimum && matrix[i, j] != 0)
                        {
                            searchOfMinimum = matrix[i, j];
                            iMin = i;
                            jMin = j;
                        }
                    }
                }
                pathLength += searchOfMinimum;
                matrix[iMin, jMin] = 0;
                if (!visitedEdges.Contains(iMin))
                {
                    edges.Remove(iMin);
                    visitedEdges.Add(iMin);
                }
                else if (!visitedEdges.Contains(jMin))
                {
                    edges.Remove(jMin);
                    visitedEdges.Add(jMin);
                }
                searchOfMinimum = maxima.Max();
            }
        }

        Console.WriteLine("Минимальный вес оставного дерева = " + pathLength);
    }
}
