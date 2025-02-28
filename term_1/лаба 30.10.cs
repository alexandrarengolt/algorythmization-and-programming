//Задача 1
using System;
class HelloWorld {
  static void Main() {
 int n3 = 1;
 n3 = Convert.ToInt32(Console.ReadLine());
 int[] array1 = new int[n3];
 for (int i = 0; i < array1.Length; i++)
 {
     int elem = Convert.ToInt32(Console.ReadLine());
     array1[i] = elem;
 }
 int positiveIndex = 0;
 int negativeIndex = array1.Length - 1;

 while (positiveIndex <= negativeIndex)
 {
     // Если текущий элемент положительный, то оставляем его на месте и увеличиваем указатель для положительных элементов
     if (array1[positiveIndex] >= 0)
     {
         positiveIndex++;
     }
     // Иначе если текущий элемент отрицательный, то меняем его местами с элементом по отрицательному указателю и уменьшаем отрицательный указатель
     else
     {
         int temp = array1[positiveIndex];
         array1[positiveIndex] = array1[negativeIndex];
         array1[negativeIndex] = temp;
         negativeIndex--;
     }
 }

 // Выводим выходной массив
 foreach (int number in array1)
 {
     Console.WriteLine(number);
 }
  }
}


//Задача 2 
using System;
class HelloWorld {
  static void Main() {
    int n = Convert.ToInt32(Console.ReadLine());
int[] array1 = new int[n];
bool flag = true;
for (int i = 0; i < array1.Length; i++)
{
    int elem = Convert.ToInt32(Console.ReadLine());
    array1[i] = elem;
}

for (int i = 1; i < array1.Length-1; i++)
{ 
    if (array1[i] < array1[i+1])
    {
        flag=false;
    }
}
if (flag)
{
    Console.WriteLine("ДА");
}
else
{
    Console.WriteLine("НЕТ");
}
  }
}


//задача 3
using System;
class HelloWorld {
  static void Main() {
    int n = Convert.ToInt32(Console.ReadLine());
int[] array1 = new int[n];
int cnt = 0;
for (int i = 0; i < array1.Length; i++)
{
    int elem = Convert.ToInt32(Console.ReadLine());
    array1[i] = elem;
}

foreach (var num in array1)
{
    if (num % 2 ==0)
    {
        cnt++;
    }
}
if (cnt == array1.Length)
{
    Console.WriteLine("ДА");
}
else
{
    Console.WriteLine("НЕТ");
}
  }
}
