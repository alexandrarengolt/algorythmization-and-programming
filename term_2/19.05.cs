using System;

class Program
{
    static unsafe void Main()
    {
        Console.WriteLine("Задайте размер массива: ");
        int size = int.Parse(Console.ReadLine());
        
        
        int* array = stackalloc int[size];

        Console.WriteLine($"Введите {size} целых чисел:");
        for (int i = 0; i < size; i++)
        {
            if (!int.TryParse(Console.ReadLine(), out array[i]))
            {
                Console.WriteLine("Ошибка ввода! Будет установлено значение 0.");
                array[i] = 0;
            }
        }

        Console.WriteLine("\nНайденные палиндромы:");
        bool found = false;
        for (int i = 0; i < size; i++)
        {
            if (IsPalindrome(array[i]))
            {
                Console.WriteLine($"{array[i]} (индекс {i}) - палиндром");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Палиндромы не найдены.");
        }
    }

    static bool IsPalindrome(int num)
    {
        
        if (num < 0) return false;
        
        
        if (num < 10) return true;

        int original = num;
        int reversed = 0;
        
        
        while (num > 0)
        {
            reversed = reversed * 10 + num % 10;
            num /= 10;
        }

        return original == reversed;
    }
}
