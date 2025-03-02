using System;
namespace PhoneBook
{
    class Users
    {
        public string Name { get; set; }
        public string City { get; set; }
        public long[] Numbers { get; set; }

        public Users(int size, string name, string city)
        {
            Numbers = new long[size];
            Name = name;
            City = city;
        }

        public void UserInfo()
        {
            Console.WriteLine($"ФИО: {Name}, Город: {City}, Номера: {string.Join(", ", Numbers)}");
        }
    }

    class Number
    {
        public long PhoneNumber { get; set; }
        public string Operator { get; set; }
        public int Year { get; set; }

        public Number(long num, string oper, int year)
        {
            PhoneNumber = num;
            Operator = oper;
            Year = year;
        }

        public void NumberInfo()
        {
            Console.WriteLine($"Номер: {PhoneNumber}, Оператор: {Operator}, Год контракта: {Year}");
        }
    }

    class Program
    {
        public static void NumChoice(Users[] users, Number[] numbers, long num)
        {
            foreach (var number in numbers)
            {
                if (number != null && number.PhoneNumber == num)
                {
                    foreach (var user in users)
                    {
                        if (user == null) continue;

                        foreach (var userNum in user.Numbers)
                        {
                            if (userNum == num)
                            {
                                user.UserInfo();
                                number.NumberInfo();
                            }
                        }
                    }
                }
            }
        }

        public static void OperChoice(Users[] users, Number[] numbers, string oper)
        {
            foreach (var number in numbers)
            {
                if (number != null && number.Operator == oper)
                {
                    foreach (var user in users)
                    {
                        if (user == null) continue;

                        foreach (var userNum in user.Numbers)
                        {
                            if (userNum == number.PhoneNumber)
                            {
                                user.ShowUserData();
                                number.ShowNumberData();
                            }
                        }
                    }
                }
            }
        }

        public static void YearChoice(Users[] users, Number[] numbers, int year)
        {
            foreach (var number in numbers)
            {
                if (number != null && number.Year == year)
                {
                    foreach (var user in users)
                    {
                        if (user == null) continue;

                        foreach (var userNum in user.Numbers)
                        {
                            if (userNum == number.PhoneNumber)
                            {
                                user.ShowUserData();
                                number.ShowNumberData();
                            }
                        }
                    }
                }
            }
        }

        static void Main()
        {
            Console.WriteLine("Введите количество пользователей: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите суммарное количество номеров у всех пользователей:");
            int d = Convert.ToInt32(Console.ReadLine());

            Users[] users = new Users[n];
            Number[] numbers = new Number[d];
            int numCounter = 0;

            while (true)
            {
                //Console.Clear();
                Console.WriteLine("1. Создать пользователей");
                Console.WriteLine("2. Информация о пользователях(выборка)");
                Console.WriteLine("3. Выход");

                int choice = Convert.ToInt32(Console.ReadLine());


                if (choice == 1)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.WriteLine("Введите ФИО:");
                        string name = Console.ReadLine();

                        Console.WriteLine("Введите город:");
                        string city = Console.ReadLine();

                        Console.WriteLine("Введите количество номеров телефона:");
                        int phoneCount = Convert.ToInt32(Console.ReadLine());

                        if (numCounter + phoneCount > d)
                        {
                            Console.WriteLine("Превышено количество номеров телефона!");
                            break;
                        }

                        users[j] = new Users(phoneCount, name, city);

                        for (int i = 0; i < phoneCount; i++)
                        {
                            Console.WriteLine("Введите номер телефона:");
                            long phoneNum = Convert.ToInt64(Console.ReadLine());

                            Console.WriteLine("Введите оператора связи:");
                            string operatorName = Console.ReadLine();

                            Console.WriteLine("Введите год заключения контракта:");
                            int contractYear = Convert.ToInt32(Console.ReadLine());

                            users[j].Numbers[i] = phoneNum;
                            numbers[numCounter++] = new Number(phoneNum, operatorName, contractYear);
                        }
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("1. Поиск по номеру телефона");
                    Console.WriteLine("2. Поиск по оператору связи");
                    Console.WriteLine("3. Поиск по году заключения контракта");

                    int searchOption = Convert.ToInt32(Console.ReadLine());

                    if (searchOption == 1)
                    {
                        Console.WriteLine("Введите номер телефона:");
                        long phoneNum = Convert.ToInt64(Console.ReadLine());
                        NumChoice(users, numbers, phoneNum);
                    }
                    else if (searchOption == 2)
                    {
                        Console.WriteLine("Введите оператора связи:");
                        string operatorName = Console.ReadLine();
                        OperChoice(users, numbers, operatorName);
                    }
                    else if (searchOption == 3)
                    {
                        Console.WriteLine("Введите год заключения контракта:");
                        int year = Convert.ToInt32(Console.ReadLine());
                        YearChoice(users, numbers, year);
                    }
                }
                else if (choice == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода!");
                }
            }
        }
    }
}
