using System;
using System.Linq;
using System.Runtime.ExceptionServices;
namespace lab
{
    class Tool
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Tool(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }

    class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Phone { get; set; }

        public Provider(int id, string name, long phone)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
        }
    }

    class DeliveryInfo
    {
        public int ProviderId { get; set; }
        public int ToolId { get; set; }
        public int Price { get; set; }
        public string[] Dates { get; set; }
        public int[] Amounts { get; set; }

        public DeliveryInfo(int providerId, int toolId, int price, int deliveriesCount)
        {
            this.ProviderId = providerId;
            this.ToolId = toolId;
            this.Price = price;
            Dates = new string[deliveriesCount];
            Amounts = new int[deliveriesCount];
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите количество товаров: ");
            int toolsCount = Convert.ToInt32(Console.ReadLine());
            Tool[] tools = new Tool[toolsCount];
            DeliveryInfo[] deliveries = new DeliveryInfo[toolsCount];

            Console.WriteLine("Введите количество поставщиков: ");
            int providersCount = Convert.ToInt32(Console.ReadLine());
            Provider[] providers = new Provider[providersCount];

            while (true)
            {
                Console.WriteLine("1. Ввести данные");
                Console.WriteLine("2. Информация о товарах ");
                Console.WriteLine("3. Выход");

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    for (int i = 0; i < toolsCount; i++)
                    {
                        Console.WriteLine("Введите номер товара:");
                        int toolId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Введите наименование товара:");
                        string toolName = Console.ReadLine();

                        tools[i] = new Tool(toolId, toolName);
                    }

                    for (int i = 0; i < providersCount; i++)
                    {
                        Console.WriteLine("Введите номер поставщика: ");
                        int providerId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Введите наименование поставщика: ");
                        string providerName = Console.ReadLine();

                        Console.WriteLine("Введите номер телефона поставщика: ");
                        long phoneNumber = Convert.ToInt64(Console.ReadLine());

                        providers[i] = new Provider(providerId, providerName, phoneNumber);
                    }

                    for (int i = 0; i < toolsCount; i++)
                    {
                        Console.WriteLine("Введите номер поставщика: ");
                        int providerId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Введите номер товара:");
                        int toolId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Введите на какую сумму поставили товар: ");
                        int totalPrice = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Введите сколько раз поставляли товар: ");
                        int deliveriesCount = Convert.ToInt32(Console.ReadLine());

                        deliveries[i] = new DeliveryInfo(providerId, toolId, totalPrice, deliveriesCount);

                        for (int j = 0; j < deliveriesCount; j++)
                        {
                            Console.WriteLine("Дата поставки: ");
                            string deliveryDate = Console.ReadLine();
                            deliveries[i].Dates[j] = deliveryDate;

                            Console.WriteLine("Введите количество товара");
                            int amount = Convert.ToInt32(Console.ReadLine());
                            deliveries[i].Amounts[j] = amount;
                        }
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("1. Поставщик, поставивший товар на наибольшую сумму");
                    Console.WriteLine("2. Поставки, сгруппированные по датам");
                    Console.WriteLine("3. Товары, сгруппированные по поставщику");
                    Console.WriteLine("4. Товар, который поставляется чаще всего");
                    Console.WriteLine("5. Суммы поставок, сгруппированные по поставщику");

                    int subChoice = Convert.ToInt32(Console.ReadLine());

                    if (subChoice == 1)
                    {
                        int maxCost = 0;
                        foreach (var delivery in deliveries)
                        {
                            for (int j = 0; j < toolsCount; j++)
                            {
                                maxCost = Math.Max(maxCost, delivery.Price);
                            }
                        }
                        foreach (var delivery in deliveries)
                        {
                            if (maxCost == delivery.Price)
                            {
                                int providerWithMaxCost = delivery.ProviderId;
                                foreach (var provider in providers)
                                {
                                    if (providerWithMaxCost == provider.Id) 
                                        Console.WriteLine(provider.Name);
                                }
                            }
                        }
                    }
                    if (subChoice == 2)
                    {
                        var deliveriesByDate = from delivery in deliveries
                                              join tool in tools on delivery.ToolId equals tool.Id
                                              from index in Enumerable.Range(0, delivery.Dates.Length)
                                              let date = delivery.Dates[index]
                                              let amounts = delivery.Amounts
                                              group new { date, amounts, ToolName = tool.Name } by date into grouped
                                              select grouped;
                                              
                        foreach(var dateGroup in deliveriesByDate)
                        {
                            Console.WriteLine($"Дата: {dateGroup.Key}");
                            foreach(var item in dateGroup)
                            {
                                Console.WriteLine($"Товар: {item.ToolName}");
                            }
                        }
                    }
                    if (subChoice == 3)
                    {
                        var toolsByProvider = from delivery in deliveries
                                              join provider in providers on delivery.ProviderId equals provider.Id
                                              join tool in tools on delivery.ToolId equals tool.Id
                                              let totalAmount = delivery.Amounts.Sum()
                                              group new { tool, totalAmount } by provider.Name into grouped
                                              orderby grouped.Sum(x => x.totalAmount) descending
                                              select new
                                              {
                                                  ProviderName = grouped.Key,
                                                  Items = grouped
                                              };

                        foreach (var providerGroup in toolsByProvider)
                        {
                            Console.WriteLine("Поставщик: " + providerGroup.ProviderName);
                            foreach (var item in providerGroup.Items)
                            {
                                Console.WriteLine($"Товар: {item.tool.Name}");
                            }
                            Console.WriteLine();
                        }
                    }
                    if (subChoice == 4)
                    {
                        int maxDeliveries = 0;
                        foreach (var delivery in deliveries)
                        {
                            for (int j = 0; j < toolsCount; j++)
                            {
                                maxDeliveries = Math.Max(maxDeliveries, delivery.Dates.Length);
                            }
                        }
                        foreach (var delivery in deliveries)
                        {
                            if (maxDeliveries == delivery.Dates.Length)
                            {
                                int mostDeliveredToolId = delivery.ToolId;
                                foreach (var tool in tools)
                                {
                                    if (mostDeliveredToolId == tool.Id) 
                                        Console.WriteLine(tool.Name);
                                }
                            }
                        }
                    }
                    if (subChoice == 5)
                    {
                        var sumsByProvider = from delivery in deliveries
                                            join provider in providers on delivery.ProviderId equals provider.Id
                                            orderby delivery.Price
                                            group new { delivery, provider } by provider.Name into grouped
                                            select new
                                            {
                                                ProviderName = grouped.Key,
                                                Items = grouped
                                            };
                        foreach (var providerGroup in sumsByProvider)
                        {
                            Console.WriteLine($"Поставщик: {providerGroup.ProviderName}");
                            foreach (var item in providerGroup.Items)
                            {
                                Console.WriteLine($"Сумма поставок: {item.delivery.Price}");
                            }
                            Console.WriteLine();
                        }
                    }
                }
                else if (choice == 3) break;
            }
        }

        static int Sum(int[] array)
        {
            int sum = 0;
            foreach (int value in array)
            {
                sum += value;
            }
            return sum;
        }
    }
}
