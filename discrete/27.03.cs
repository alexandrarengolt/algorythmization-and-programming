using System;
using System.Collections.Generic;
using System.Linq;
namespace Wave_algoritm
{

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите координаты начальной вершины - ");
        int x1 = int.Parse(Console.ReadLine());
        int y1 = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Введите координаты конечной вершины - ");
        int x2 = int.Parse(Console.ReadLine());
        int y2 = int.Parse(Console.ReadLine());

        List<List<int>> matrix = new List<List<int>> {
            new List<int> { 0, 0, 0, -1, -1 },
            new List<int> { 0, -1, 0, 0, 0 },
            new List<int> { 0, -1, 0, -1, 0 },
            new List<int> { 0, 0, 0, -1, 0 },
            new List<int> { 0, 0, 0, -1, 0 }
        };

        
        foreach (var row in matrix.ToList())
        {
            row.Insert(0, -1);
            row.Add(-1);
        }
        matrix.Insert(0, Enumerable.Repeat(-1, matrix[0].Count).ToList());
        matrix.Add(Enumerable.Repeat(-1, matrix[0].Count).ToList());

        
        if (matrix[x1 - 1][y1] != -1) matrix[x1 - 1][y1] += 1;
        if (matrix[x1 + 1][y1] != -1) matrix[x1 + 1][y1] += 1;
        if (matrix[x1][y1 - 1] != -1) matrix[x1][y1 - 1] += 1;
        if (matrix[x1][y1 + 1] != -1) matrix[x1][y1 + 1] += 1;

        bool flag = true;
        List<List<int>> matrixCopy = new List<List<int>>();

        while (matrix.Any(row => row.Contains(0)) && flag)
        {
            
            matrixCopy = matrix.Select(row => new List<int>(row)).ToList();

            for (int i = 1; i < matrix.Count - 1; i++)
            {
                for (int j = 1; j < matrix[i].Count - 1; j++)
                {
                    if (matrix[i][j] != 0 && matrix[i][j] != -1)
                    {
                        if (matrix[i - 1][j] != -1 && matrix[i - 1][j] == 0)
                            matrix[i - 1][j] = matrix[i][j] + 1;
                            
                        if (matrix[i + 1][j] != -1 && matrix[i + 1][j] == 0)
                            matrix[i + 1][j] = matrix[i][j] + 1;
                            
                        if (matrix[i][j - 1] != -1 && matrix[i][j - 1] == 0)
                            matrix[i][j - 1] = matrix[i][j] + 1;
                            
                        if (matrix[i][j + 1] != -1 && matrix[i][j + 1] == 0)
                            matrix[i][j + 1] = matrix[i][j] + 1;
                    }
                }
            }

            
            flag = !MatrixComparison(matrix, matrixCopy);
        }

        if (!flag)
        {
            Console.WriteLine("Невозможно достичь конечной вершины");
        }
        else
        {
            Console.WriteLine($"Число шагов = {matrix[x2][y2]}");
        }
    }

    
    static bool MatrixComparison(List<List<int>> a, List<List<int>> b)
    {
        if (a.Count != b.Count) return false;
        for (int i = 0; i < a.Count; i++)
        {
            if (a[i].Count != b[i].Count) return false;
            for (int j = 0; j < a[i].Count; j++)
            {
                if (a[i][j] != b[i][j]) return false;
            }
        }
        return true;
    }
}
}
