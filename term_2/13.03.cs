///Задание 1
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
public delegate void Operation();
namespace delegates
{
    class Numbers
    {
        public int FirstNum { get; set; }
        public int SecondNum { get; set; }
        public Numbers(int num_1, int num_2)
        {
            FirstNum = num_1;
            SecondNum = num_2;
        }

        public void Add()
        {
            FirstNum = FirstNum + SecondNum;
            
        }
        public void Multiplication()
        {
            FirstNum = FirstNum * SecondNum;
        }
        public void Difference()
        {
            FirstNum = FirstNum - SecondNum;
        }
        public void Div()
        {
            if (SecondNum != 0) FirstNum = FirstNum / SecondNum;
            else Console.WriteLine("Деление на 0");
        }
        public void PrintResult()
        {
            Console.WriteLine("Результат: " + FirstNum);
        }

    }
    class Program
    {
        static void Main()
        { 
            Console.WriteLine("Введите первое число: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе число: ");
            int y = Convert.ToInt32(Console.ReadLine());
            Numbers couple1 = new Numbers(x, y);

            Operation first = couple1.Add;
            first += couple1.Difference;
            first += couple1.Div;
            first += couple1.PrintResult;
            first();

            Console.WriteLine("Введите третье число: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите четвертое число: ");
            int b = Convert.ToInt32(Console.ReadLine());
            Numbers couple2 = new Numbers(a, b);

            Operation second = couple2.Multiplication;
            second += couple2.Add;
            second += couple2.PrintResult;
            second();

        }
    }
}
///Задание 2
using System;
using System.Collections.Generic;
namespace washing
{

    public delegate void WashCarDelegate(Car car);

    public class Car
    {
        public int Year { get; set; }
        public string Brand { get; set; }
        public string Owner { get; set; }
        public bool IsWashed { get; set; }

        public Car(int year, string brand, string owner, bool isWashed)
        {
            Year = year;
            Brand = brand;
            Owner = owner;
            IsWashed = isWashed;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Марка: {Brand}, Год: {Year}, Владелец: {Owner}, Помыта: {IsWashed}");
        }
    }

    public class Garage
    {
        public List<Car> Cars { get; } = new List<Car>();

        public void AddCar(Car car) => Cars.Add(car);

        public void PrintAllCars(string message)
        {
            Console.WriteLine($"\n{message}:");
            foreach (var car in Cars)
            {
                car.PrintInfo();
            }
        }
    }

    public class CarWash
    {
        public void Wash(Car car)
        {
            Console.WriteLine($"\nСостояние до мойки: {car.Brand} - Помыта: {car.IsWashed}");

            if (!car.IsWashed)
            {
                car.IsWashed = true;
                Console.WriteLine($"Моем {car.Brand}... Готово!");
            }
            else
            {
                Console.WriteLine($"{car.Brand} уже чистая");
            }

            Console.WriteLine($"Состояние после мойки: {car.Brand} - Помыта: {car.IsWashed}");
        }
    }

    class Program
    {
        static void Main()
        {
            Garage garage = new Garage();
            garage.AddCar(new Car(2006, "Toyota Camry", "Васенева М.", false));
            garage.AddCar(new Car(2015, "BMW X5", "Секисова О.", true));
            garage.AddCar(new Car(2021, "Maserati", "Козловская К.", false));
            garage.AddCar(new Car(1886, "Benz Patent-Motorwagen", "Ренгольт А.", false));

            garage.PrintAllCars("Машины в гараже (до мойки)");

            CarWash carWash = new CarWash();
            WashCarDelegate washDelegate = carWash.Wash;

            Console.WriteLine("\n=== Процесс мойки ===");
            foreach (var car in garage.Cars)
            {
                if (!car.IsWashed)
                {
                    washDelegate(car);
                }
                else
                {
                    Console.WriteLine($"\n{car.Brand} уже чистая.");
                }
            }

            garage.PrintAllCars("Машины в гараже:");
        }
    }
}
