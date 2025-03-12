public class PolishNotation
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите выражение:");
        string line = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(line))
        {
            Console.WriteLine("Введена пустая строка.");
            return;
        }

        string[] symbols = line.Split(' ');
        Stack<double> stack = new Stack<double>();

        foreach (string symbol in symbols)
        {
            if (double.TryParse(symbol, out double number))
            {
                
                stack.Push(number);
            }
            else if (IsOperator(symbol))
            {
                
                if (stack.Count < 2)
                {
                    Console.WriteLine("Недостаточно операндов.");
                    return;
                }

                double oper2 = stack.Pop();
                double oper1 = stack.Pop();
                double res = CalculateRes (oper1, oper2, symbol);
                stack.Push(res);
            }
            else
            {
                Console.WriteLine($"Операция невозможна: {symbol}");
                return;
            }
        }

        if (stack.Count == 1)
        {
            Console.WriteLine($"Результат: {stack.Pop()}");
        }
        else
        {
            Console.WriteLine("Некорректное выражение.");
        }
    }

    public static bool IsOperator(string oper)
    {
        return oper == "+" || oper == "-" || oper == "*" || oper == "/";
    }

    public static double CalculateRes(double oper1, double oper2, string operatorToken)
    {
        switch (operatorToken)
        {
            case "+": return oper1 + oper2;
            case "-": return oper1 - oper2;
            case "*": return oper1 * oper2;
            case "/":
                if (oper2 == 0)
                {
                    Console.WriteLine("Деление на ноль.");
                    return double.NaN;
                    
                }
                return oper1 / oper2;
            default: return double.NaN;
        }
    }
}
