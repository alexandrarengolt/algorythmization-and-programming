using System;
namespace Floyd
{
    class Program
    {
        static void Main()
        {
            int[,] matrix = {
                { 0, 10, 18, 8, 0, 0 },
                { 10, 0, 16, 9, 21, 0 },
                { 0, 16, 0, 0, 0, 15 },
                { 7, 9, 0, 0, 0, 12 },
                { 0, 0, 0, 0, 0, 23 },
                { 0, 0, 15, 0, 23, 0 }
            };

            int size = matrix.GetLength(0);
            int zero = int.MaxValue / 2;
            int[,] newMatrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] == 0 && i != j)
                        newMatrix[i, j] = zero;
                    else
                        newMatrix[i, j] = matrix[i, j];
                }
            }

            for (int k = 0; k < size; k++)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        newMatrix[i, j] = Math.Min(newMatrix[i, j], newMatrix[i, k] + newMatrix[k, j]);
                    }
                }
            }

            Console.WriteLine("       1     2    3     4     5    6");

            for (int i = 0; i < size; i++)
            {
                Console.Write($"{i + 1,2} ");
                for (int j = 0; j < size; j++)
                {
                    if (newMatrix[i, j] == zero)
                        Console.Write("| 0");
                    else
                        Console.Write($"| {newMatrix[i, j],3} ");
                }
                Console.WriteLine();
            }
        }
    }
}
