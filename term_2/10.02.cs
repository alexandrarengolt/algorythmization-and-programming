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

    class PNumber
    {
        public long PhoneNumber { get; set; }
        public string Operator { get; set; }
        public int Year { get; set; }

        public PNumber(long num, string oper, int year)
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
        public static void NumSearch(Users[] users, PNumber[] numbers, long num)
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

        public static void OperSearch(Users[] users, PNumber[] numbers, string oper)
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
                                user.UserInfo();
                                number.NumberInfo();
                            }
                        }
                    }
                }
            }
        }

        public static void YearSearch(Users[] users, PNumber[] numbers, int year)
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
                                user.UserInfo();
                                number.NumberInfo();
                            }
                        }
                    }
                }
            }
        }

        static void Main()
        {
            Console.WriteLine("Введите количество пользователей: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите общее количество номеров у всех пользователей:");
            int b = Convert.ToInt32(Console.ReadLine());

            Users[] users = new Users[a];
            PNumber[] numbers = new PNumber[b];
            int count = 0;

            while (true)
            {
                
                Console.WriteLine("1. Создать пользователей");
                Console.WriteLine("2. Информация о пользователях");
                Console.WriteLine("3. Выход");

                int variant = Convert.ToInt32(Console.ReadLine());


                if (variant == 1)
                {
                    for (int j = 0; j < a; j++)
                    {
                        Console.WriteLine("Введите ФИО:");
                        string name = Console.ReadLine();

                        Console.WriteLine("Введите город:");
                        string city = Console.ReadLine();

                        Console.WriteLine("Введите количество номеров телефона:");
                        int phoneCount = Convert.ToInt32(Console.ReadLine());

                        if (count + phoneCount > b)
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
                            numbers[count++] = new PNumber(phoneNum, operatorName, contractYear);
                        }
                    }
                }
                else if (variant == 2)
                {
                    Console.WriteLine("1. Поиск по номеру телефона");
                    Console.WriteLine("2. Поиск по оператору связи");
                    Console.WriteLine("3. Поиск по году заключения контракта");

                    int searchOption = Convert.ToInt32(Console.ReadLine());

                    if (searchOption == 1)
                    {
                        Console.WriteLine("Введите номер телефона:");
                        long phoneNum = Convert.ToInt64(Console.ReadLine());
                        NumSearch(users, numbers, phoneNum);
                    }
                    else if (searchOption == 2)
                    {
                        Console.WriteLine("Введите оператора связи:");
                        string operatorName = Console.ReadLine();
                        OperSearch(users, numbers, operatorName);
                    }
                    else if (searchOption == 3)
                    {
                        Console.WriteLine("Введите год заключения контракта:");
                        int year = Convert.ToInt32(Console.ReadLine());
                        YearSearch(users, numbers, year);
                    }
                }
                else if (variant == 3)
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

