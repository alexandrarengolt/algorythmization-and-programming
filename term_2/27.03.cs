using System;

//Задание 1

var sum = (int a, int b) => a + b;

var diff = (int a, int b) => a - b;

var mult = (int a, int b) => a * b;

var div = (int a, int b) =>
{
  if (b == 0)
  {
    throw new DivideByZeroException("Деление на ноль");
  }
  else
  {
    return a / b;
  }
};

Console.WriteLine(sum(8, 34));
Console.WriteLine(diff(31, 1));
Console.WriteLine(mult(5, 6));
Console.WriteLine(div(9, 3)); 
Console.WriteLine(div(9, 0));


//Задание 2

List<String> list = new List<String> { "m", "sd", "mm", "mf", "jz" };

var isStartsWithM = (string s) => s.StartsWith('m');

foreach (string word in list)
{
  if (isStartsWithM(word))
  {
    Console.WriteLine(word);
  }
}
