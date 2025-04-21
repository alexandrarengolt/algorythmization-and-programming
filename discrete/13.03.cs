using System;
namespace Ford_Bellman
{

class Program
{
    static void Main()
    {
        int[][] matrix = new int[][]
        {
            new int[] {0, 1, 0, 0, 3},
            new int[] {0, 0, 8, 7, 1},
            new int[] {0, 0, 0, 1, -5},
            new int[] {0, 0, 2, 0, 0},
            new int[] {0, 0, 0, 4, 0}
        };

        int size = matrix[0].Length;

        
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (matrix[i][j] == 0)
                {
                    matrix[i][j] = int.MaxValue;
                }
            }
        }

        
        double[][] tab = new double[size][];
        for (int i = 0; i < size; i++)
        {
            tab[i] = new double[size];
            for (int j = 0; j < size; j++)
            {
                tab[i][j] = double.PositiveInfinity;
            }
        }
        tab[0][0] = 0;

        
        for (int k = 1; k < size; k++)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[j][i] != int.MaxValue)
                    {
                        if (tab[j][k - 1] + matrix[j][i] < tab[i][k])
                        {
                            tab[i][k] = tab[j][k - 1] + matrix[j][i];
                        }
                    }
                }
            }
        }

        
        double[][] tabCopy = new double[size][];
        for (int i = 0; i < size; i++)
        {
            tabCopy[i] = new double[size];
            Array.Copy(tab[i], tabCopy[i], size);
        }

        
        for (int k = 1; k < size; k++)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[j][i] != int.MaxValue)
                    {
                        if (tabCopy[j][k - 1] + matrix[j][i] < tabCopy[i][k])
                        {
                            tabCopy[i][k] = tabCopy[j][k - 1] + matrix[j][i];
                        }
                    }
                }
            }
        }

        
        bool isNegative = false;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (Math.Abs(tab[i][j] - tabCopy[i][j]) > 0.0001)
                {
                    isNegative = true;
                    break;
                }
            }
            if (isNegative) break;
        }

        if (!isNegative)
        {
            for (int m = 0; m < tab.Length; m++)
            {
                Console.WriteLine(string.Join("\t", tab[m]));
            }
        }
        else
        {
            Console.WriteLine("В графе есть отрицательный цикл");
        }
    }
}
}
