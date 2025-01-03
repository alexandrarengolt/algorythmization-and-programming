using System;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 1
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Console.WriteLine("Введите строку:");
            string line1 = Console.ReadLine().ToUpper();
            int[] symbolsCount = new int[26];

            for (int i = 1; i < line1.Length - 1; i++)
            {
                if ((line1[i - 1] == 'A' || line1[i - 1] == 'a') && (line1[i + 1] == 'B' || line1[i + 1] == 'b'))
                {
                    symbolsCount[char.ToUpper(line1[i]) - 65]++;
                }
            }
            int maxElement = -100;
            int maxIndex = 0;
            for (int i = 0; i < symbolsCount.Length; i++)
            {
                if (symbolsCount[i] > maxElement)
                {
                    maxElement = symbolsCount[i];
                    maxIndex = i;
                }
            }
            Console.WriteLine($"Самый частый символ в комбинации a*b: {alphabet[maxIndex]}");

            // Задание 2
            Console.WriteLine("Введите строку:");
            string line2 = Console.ReadLine();

            CheckString(line2);

            string[] lines = { "ababab", "abcaba", "aababc", "abcabc", "abcabca", "abcabcab", "abcabcc", "ccaabcbcababcabc" };
            Console.WriteLine("Результаты для массива строк:");
            foreach (string line in lines)
            {
                CheckString(line);
            }
        }

        static void CheckString(string str)
        {
            string newLine = str.ToLower();
            newLine = newLine.Replace("abc", "3");
            newLine = newLine.Replace("ab", "2");
            newLine = newLine.Replace("a", "1");

            int maxLength = 0;
            int currentLength = 0;

            for (int i = 0; i < newLine.Length; i++)
            {
                switch (newLine[i])
                {
                    case '3':
                        currentLength += 3;
                        break;
                    case '2':
                        currentLength += 2;
                        break;
                    case '1':
                        currentLength += 1;
                        break;
                    default:
                        maxLength = Math.Max(maxLength, currentLength);
                        currentLength = 0;
                        break;
                }
            }
            maxLength = Math.Max(maxLength, currentLength);
            Console.WriteLine($"Максимальная длина подпоследовательности: {maxLength}");
        }
    }
}

