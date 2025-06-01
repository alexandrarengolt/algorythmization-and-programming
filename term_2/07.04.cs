using System;

namespace lab
{
    class WorkWithArray<T>
    {
        public T[] Items;
        public int Count;

        public WorkWithArray(T[] items, int count)
        {
            Items = items;
            Count = count;
        }

        public void DeleteElement(int indexToDelete)
        {
            if (indexToDelete >= 0 && indexToDelete < Count)
            {
                T[] newItems = new T[Count - 1];
                for (int i = 0, j = 0; i < Count; i++)
                {
                    if (i != indexToDelete)
                        newItems[j++] = Items[i];
                }

                Items = newItems;
                Count--;
                Console.WriteLine("Массив после удаления:");
                foreach (var item in Items) Console.Write(item + " ");    
                Console.WriteLine();
            }
            else Console.WriteLine("Вы вышли за пределы массива!");   
        }

        public void PrintElement(int indexToPrint)
        {
            if (indexToPrint >= 0 && indexToPrint < Count)
            {
                Console.WriteLine($"Элемент с индексом {indexToPrint}: {Items[indexToPrint]}");
            }
            else Console.WriteLine("Вы вышли за пределы массива!");
        }

        public void AddElement(T element)
        {
            T[] newItems = new T[Count + 1];
            for (int i = 0; i < Count; i++) newItems[i] = Items[i];   
            newItems[Count] = element;

            Items = newItems;
            Count++;

            Console.WriteLine("Массив после добавления:");
            foreach (var item in Items) Console.Write(item + " ");     
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main()
        {
            int[] numArray = new int[] { 1, 2, 3, 5, 6 };

            Console.WriteLine("Индекс элемента, который хотите удалить: ");
            int deleteIndexNum = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Индекс элемента, который хотите вывести: ");
            int printIndexNum = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Элемент для добавления (int): ");
            int newNumber = Convert.ToInt32(Console.ReadLine());

            WorkWithArray<int> intArrayInstance = new WorkWithArray<int>(numArray, numArray.Length);
            intArrayInstance.DeleteElement(deleteIndexNum);
            intArrayInstance.PrintElement(printIndexNum);
            intArrayInstance.AddElement(newNumber);

            string[] strArray = new string[] { "s", "t", "r", "a", "y", "k", "i", "d", "s" };

            Console.WriteLine("Индекс элемента, который хотите удалить: ");
            int deleteIndexStr = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Индекс элемента, который хотите вывести: ");
            int printIndexStr = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Элемент для добавления (string): ");
            string newString = Console.ReadLine();

            WorkWithArray<string> strArrayInstance = new WorkWithArray<string>(strArray, strArray.Length);
            strArrayInstance.DeleteElement(deleteIndexStr);
            strArrayInstance.PrintElement(printIndexStr);
            strArrayInstance.AddElement(newString);
        }
    }
}
