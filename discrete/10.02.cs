using System;

public class GraphConnect
{
    static void Dfs(int v, int num, int[,] matrix, int[] component)
    {
        component[v] = num;
        for (int u = 0; u < matrix.GetLength(0); u++)
        {
            if (matrix[v, u] == 1 && component[u] == 0)
            {
                Dfs(u, num, matrix, component);
            }
        }
    }

    public static void Main(string[] args)
    {
        Console.Write("Введите число вершин: ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];
        Console.WriteLine("Введите матрицу смежности. Это будет непросто. Нужно вводить числа в каждой строке через пробел, затем после каждой строки нажимать Enter. Крепитесь.:");
        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            string[] numbers = line.Split(' '); 

            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = int.Parse(numbers[j]);
            }
        }

        int[] component = new int[n]; 

        int num = 0;
        for (int v = 0; v < n; v++)
        {
            if (component[v] == 0)
            {
                Dfs(v, ++num, matrix, component);
            }
        }

        Console.WriteLine("Число компонент связности: " + num);
    }
}
