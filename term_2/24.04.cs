using System;
namespace lab
{
  class Car
  {
    public string Brand;
    public int Year;
    public string City;
    public Car(string brand, int year, string city)
    {
      this.Brand = brand;
      this.Year = year;
      this.City = city;
    }
  }

  public class Menu
  {
    private Logic logic;

    public Menu(Logic logicLayer)
    {
      this.logic = logicLayer;
    }

    public void Run()
    {
      bool isExit = false;
      while (!isExit)
      {
        Console.Clear();

        DisplayMainMenu();
        string userInput = Console.ReadLine();

        switch (userInput)
        {
          case "1":
            logic.Option1();
            break;
          case "2":
            Selectors();
            break;
          case "q":
            isExit = true;
            break;
          default:
            Console.Write("Ошибка.");
            Console.ReadKey();
            break;
        }
      }
    }

    public void Selectors()
    {
      bool isExit = false;
      while (!isExit)
      {
        Console.Clear();

        DisplaySelectionMenu();
        Console.Write("Выберите действие: ");
        string userChoice = Console.ReadLine();

        switch (userChoice)
        {
          case "1":
            logic.Option2();
            break;
          case "2":
            logic.Option3();
            break;
          case "3":
            logic.Option4();
            break;
          case "q":
            isExit = true;
            break;
          default:
            Console.Write("Ошибка.");
            Console.ReadKey();
            break;
        }

      }
    }

    public void DisplayMainMenu()
    {
      Console.WriteLine("-- Главное меню --\n\nВыберите действие:\n(1) - Создание машины\n(2) - Выборки\n(q) - Выход\n");
    }

    public void DisplaySelectionMenu()
    {
      Console.WriteLine("-- Выборки --\n\nВыберите действие:\n(1) - Вывести данные по каждой марке автомобиля\n(2) - Вывести данные по заданному году выпуска\n(3) - Вывести данные группированные по городу\n(q) - Выход\n");
    }
  }
  public class Logic
  {
    List<Car> cars = new List<Car>{
      new Car("Lada", 2111, "Петербург"),
      new Car("Huawei", 2006, "Караганда"),
      new Car("Каждый день", 2022, "Нью Йорк")
    };

    public void Option1()
    {
      Console.Clear();

      Console.WriteLine("-- Создание машины --\n\n");
      Console.Write("Введите марку машины: ");
      string inputBrand = Console.ReadLine();
      Console.Write("Введите год выпуска машины: ");
      int inputYear = int.Parse(Console.ReadLine());
      Console.Write("Введите город регистрации машины: ");
      string inputCity = Console.ReadLine();

      cars.Add(new Car(inputBrand, inputYear, inputCity));

      Console.Write("Нажмите любую клавишу для возврата в меню...");
      Console.ReadKey();
      return;
    }

    public void Option2()
    {
      Console.Clear();
      Console.WriteLine("- Выборка по каждой марке автомобиля -\n");

      var groupedByBrand = from car in cars
                           group car by car.Brand into groupedCars
                           select groupedCars;

      foreach (var brandGroup in groupedByBrand)
      {
        Console.WriteLine($"- Марка: {brandGroup.Key}");
        foreach (var car in brandGroup)
        {
          Console.WriteLine($"Год: {car.Year}, город: {car.City}");
        }
      }

      Console.Write("Нажмите любую клавишу для возврата в меню...");
      Console.ReadKey();
    }

    public void Option3()
    {
      Console.Clear();
      Console.WriteLine("- Выборка по году выпуска автомобиля -\n");

      var groupedByYear = from car in cars
                          group car by car.Year into groupedCars
                          select groupedCars;

      foreach (var yearGroup in groupedByYear)
      {
        Console.WriteLine($"- Год: {yearGroup.Key}");
        foreach (var car in yearGroup)
        {
          Console.WriteLine($"Марка: {car.Brand}, город: {car.City}");
        }
      }

      Console.Write("Нажмите любую клавишу для возврата в меню...");
      Console.ReadKey();
    }

    public void Option4()
    {
      Console.Clear();
      Console.WriteLine("- Выборка по городу -\n");

      var groupedByCity = from car in cars
                          group car by car.City into groupedCars
                          select groupedCars;

      foreach (var cityGroup in groupedByCity)
      {
        Console.WriteLine($"- Город: {cityGroup.Key}");
        foreach (var car in cityGroup)
        {
          Console.WriteLine($"Марка: {car.Brand}, год: {car.Year}");
        }
      }

      Console.Write("Нажмите любую клавишу для возврата в меню...");
      Console.ReadKey();
    }

  }
  class Program
  {
    static void Main(string[] args)
    {
      Logic logicLayer = new Logic();
      Menu mainMenu = new Menu(logicLayer);
      mainMenu.Run();
    }
  }
}
