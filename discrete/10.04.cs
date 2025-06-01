using System;
using System.Collections.Generic;

class Program
{
    static List<List<double>> matrix;
    static List<int> columns;
    static List<int> rows;
    static List<Tuple<int, int>> path;
    static double inf = double.PositiveInfinity;

    static void Output()
    {
        for (int i = 0; i < matrix.Count; i++)
        {
            for (int j = 0; j < matrix[i].Count; j++)
            {
                Console.Write(matrix[i][j] == inf ? "inf" : matrix[i][j].ToString());
                Console.Write("\t");
            }
            Console.WriteLine(" ");
        }
        Console.WriteLine(" ");
    }

    static double FindMinInRow(int rowIndex)
    {
        double min = inf;
        for (int j = 0; j < matrix[rowIndex].Count; j++)
        {
            if (matrix[rowIndex][j] < min)
            {
                min = matrix[rowIndex][j];
            }
        }
        return min;
    }

    static double CountDeltas(int y, int x)
    {
        List<double> sum1 = new List<double>();
        List<double> sum2 = new List<double>();

        for (int i = 0; i < matrix.Count; i++)
        {
            if (i != y && i != x && rows.Contains(i))
            {
                sum1.Add(matrix[i][x]);
            }
        }

        for (int j = 0; j < matrix[y].Count; j++)
        {
            if (j != x && j != y && columns.Contains(j))
            {
                sum2.Add(matrix[y][j]);
            }
        }

        return FindMin(sum1) + FindMin(sum2);
    }

    static double FindMin(List<double> values)
    {
        double min = inf;
        foreach (double val in values)
        {
            if (val < min) min = val;
        }
        return min;
    }

    static void DeleteRowColumn(int y, int x)
    {
        rows.Remove(y);
        columns.Remove(x);
        
        for (int i = 0; i < matrix.Count; i++)
        {
            matrix[i][x] = inf;
        }
        
        for (int j = 0; j < matrix[y].Count; j++)
        {
            matrix[y][j] = inf;
        }
    }

    static void ForbidWay()
    {
        if (path.Count == 1)
        {
            matrix[path[0].Item2][path[0].Item1] = inf;
        }
        else if (path.Count == 2)
        {
            if (path[0].Item1 == path[1].Item2)
            {
                matrix[path[0].Item2][path[1].Item1] = inf;
                Console.WriteLine($"{path[0].Item2} {path[1].Item1}");
            }
            else if (path[0].Item2 == path[1].Item1)
            {
                matrix[path[0].Item1][path[1].Item2] = inf;
                Console.WriteLine($"{path[0].Item1} {path[1].Item2}");
            }
            else
            {
                matrix[path[1].Item2][path[1].Item1] = inf;
                Console.WriteLine($"{path[1].Item2} {path[1].Item1}");
            }
        }
    }

    static double SumList(List<double> list)
    {
        double sum = 0;
        foreach (double val in list)
        {
            sum += val;
        }
        return sum;
    }

    static void Main(string[] args)
    {
        matrix = new List<List<double>> {
            new List<double> {inf, 41, 80, 23, 32},
            new List<double> {41, inf, 45, 12, 37},
            new List<double> {80, 45, inf, 50, 64},
            new List<double> {23, 12, 50, inf, 67},
            new List<double> {32, 37, 64, 67, inf}
        };

        columns = new List<int>();
        rows = new List<int>();
        for (int i = 0; i < matrix.Count; i++)
        {
            columns.Add(i);
            rows.Add(i);
        }
        path = new List<Tuple<int, int>>();

        while (columns.Count + rows.Count > 4)
        {
            List<double> alpha = new List<double>();
            for (int i = 0; i < matrix.Count; i++)
            {
                alpha.Add(FindMinInRow(i));
            }
            
            Console.Write("Alpha: ");
            foreach (double val in alpha) Console.Write(val + " ");
            Console.WriteLine();

            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    if (matrix[i][j] != inf)
                    {
                        matrix[i][j] -= alpha[i];
                    }
                }
            }
            Console.WriteLine("after alpha");
            Output();

            List<double> beta = new List<double>(matrix[0]);
            for (int i = 1; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    if (matrix[i][j] < beta[j])
                    {
                        beta[j] = matrix[i][j];
                    }
                }
            }
            
            Console.Write("Beta: ");
            foreach (double val in beta) Console.Write(val + " ");
            Console.WriteLine();

            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    if (matrix[i][j] != inf)
                    {
                        matrix[i][j] -= beta[j];
                    }
                }
            }
            Console.WriteLine("after beta");
            Output();

            double mark = SumList(alpha) + SumList(beta);
            List<Tuple<int, int, double>> deltas = new List<Tuple<int, int, double>>();

            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    if (matrix[i][j] == 0 && rows.Contains(i) && columns.Contains(j))
                    {
                        deltas.Add(Tuple.Create(i, j, CountDeltas(i, j)));
                    }
                }
            }

            Console.Write("Deltas: ");
            foreach (var delta in deltas)
            {
                Console.Write($"({delta.Item1},{delta.Item2}):{delta.Item3} ");
            }
            Console.WriteLine();
            
            int maxDeltaIndex = 0;
            for (int i = 1; i < deltas.Count; i++)
            {
                if (deltas[i].Item3 > deltas[maxDeltaIndex].Item3)
                {
                    maxDeltaIndex = i;
                }
            }
            
            Console.WriteLine("Max delta index: " + maxDeltaIndex);
            path.Add(Tuple.Create(deltas[maxDeltaIndex].Item1, deltas[maxDeltaIndex].Item2));
            Console.WriteLine($"Going [{deltas[maxDeltaIndex].Item1}, {deltas[maxDeltaIndex].Item2}]");

            DeleteRowColumn(deltas[maxDeltaIndex].Item1, deltas[maxDeltaIndex].Item2);
            ForbidWay();
            Output();
            Console.Write("Path: ");
            foreach (var p in path)
            {
                Console.Write($"[{p.Item1},{p.Item2}] ");
            }
            Console.WriteLine();
            foreach (int col in columns) Console.Write(col + " ");
            Console.WriteLine();
            foreach (int row in rows) Console.Write(row + " ");
            Console.WriteLine();
            Console.WriteLine("-------");
        }
    }
}
