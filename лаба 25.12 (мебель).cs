using System;
namespace FurnitureTask
{
	class Furniture
	{
		public string name;
		public string city;
		public int cost;

		public Furniture(string name, string city, int cost)
		{
			this.name = name;
			this.city = city;
			this.cost = cost;
		}
	}

	class Chair : Furniture
	{
		public bool isSoft;
		public int legs;

		public Chair(bool isSoft, int legs, string name, string year, int cost) : base(name, year, cost)
		{
			this.isSoft = isSoft;
			this.legs = legs;
		}
	}

	class Table : Furniture
	{
		public int legs;
		public string tabletopType;

		public Table(int legs, string tabletopType, string name, string year, int cost) : base(name, year, cost)
		{
			this.legs = legs;
			this.tabletopType = tabletopType;
		}
	}

	class RenderMenu
	{
		public List<Chair> chairs = new List<Chair>();
		public List<Table> tables = new List<Table>();

		private void CreateChairs()
		{
			bool isContinue = true;
			while (isContinue)
			{
				Console.Clear();
				Console.WriteLine("-- Создание стула --\n");
				Console.WriteLine("Введите наименование: ");
				string name = Console.ReadLine();
				Console.WriteLine("Введите город производства: ");
				string city = Console.ReadLine();
				Console.WriteLine("Введите стоимость: ");
				int cost = int.Parse(Console.ReadLine());
				Console.WriteLine("Мебель магкая? (+/-)");
				bool isSoft = Console.ReadLine() == "+" ? true : false;
				Console.WriteLine("Введите кол-во ножек: ");
				int legs = int.Parse(Console.ReadLine());

				chairs.Add(new Chair(isSoft, legs, name, city, cost));
				Console.WriteLine("Продолжить создание стульев? (y/n)");
				if (Console.ReadLine() != "y")
				{
					isContinue = false;
				}
			}
		}

		private void CreateTables()
		{
			bool isContinue = true;
			while (isContinue)
			{
				Console.Clear();
				Console.WriteLine("-- Создание стола --\n");
				Console.WriteLine("Введите наименование: ");
				string name = Console.ReadLine();
				Console.WriteLine("Введите город производства: ");
				string city = Console.ReadLine();
				Console.WriteLine("Введите стоимость: ");
				int cost = int.Parse(Console.ReadLine());
				Console.WriteLine("Тип столешницы: ");
				string tabletopType = Console.ReadLine();
				Console.WriteLine("Введите кол-во ножек: ");
				int legs = int.Parse(Console.ReadLine());

				tables.Add(new Table(legs, tabletopType, name, city, cost));
				Console.WriteLine("Продолжить создание столов? (y/n)");
				if (Console.ReadLine() != "y")
				{
					isContinue = false;
				}
			}
		}

		private void FurnitureProccessCreation()
		{
			bool isContinue = true;
			while (isContinue)
			{
				Console.Clear();
				Console.WriteLine("-- Создание мебели --\n");
				Console.WriteLine($"Выбор операции:\n- Создание стульев (1)\n- Создание столов (2)\n- Выход из программы (q)");
				Console.Write("Выберите действие: ");
				string operation = Console.ReadLine();

				switch (operation)
				{
					case "1":
						CreateChairs();
						break;
					case "2":
						CreateTables();
						break;
					case "q":
						isContinue = false;
						return;
					default:
						Console.Write("Неверная операция! Для того, чтобы вернуться в меню нажмите любую клавишу...");
						Console.ReadLine();
						break;
				}
			}

		}

		private void GetFurnitureByCity()
		{
			Console.WriteLine("------------------------");
			Console.Write("Введите город: ");
			string city = Console.ReadLine();
			Console.WriteLine("------------------------");
			foreach (Table table in tables)
			{
				if (table.city == city)
				{
					Console.WriteLine("Тип: Стол");
					Console.WriteLine($"Наименование: {table.name}");
					Console.WriteLine($"Город производства: {table.city}");
					Console.WriteLine($"Стоимость: {table.cost}");
					Console.WriteLine($"Кол-во ножек: {table.legs}");
					Console.WriteLine($"Тип столешницы: {table.tabletopType}");
					Console.WriteLine("------------------------");
				}
			}
			foreach (Chair chair in chairs)
			{
				if (chair.city == city)
				{
					Console.WriteLine("Тип: Стул");
					Console.WriteLine($"Наименование: {chair.name}");
					Console.WriteLine($"Год производства: {chair.city}");
					Console.WriteLine($"Стоимость: {chair.cost}");
					Console.WriteLine($"Кол-во ножек: {chair.legs}");
					Console.WriteLine($"Мебель магкая: {chair.isSoft}");
					Console.WriteLine("------------------------");
				}
			}

			Console.Write("Для того, чтобы вернуться обратно нажмите любую клавишу...");
			Console.ReadLine();
		}

		public void GetChairsByLegs()
		{
			Console.WriteLine("------------------------");
			Console.Write("Введите кол-во ножек: ");
			int legs = int.Parse(Console.ReadLine());
			Console.WriteLine("------------------------");
			foreach (Chair chair in chairs)
			{
				if (chair.legs == legs)
				{
					Console.WriteLine("Тип: Стул");
					Console.WriteLine($"Наименование: {chair.name}");
					Console.WriteLine($"Год производства: {chair.city}");
					Console.WriteLine($"Стоимость: {chair.cost}");
					Console.WriteLine($"Кол-во ножек: {chair.legs}");
					Console.WriteLine($"Мебель магкая: {chair.isSoft}");
					Console.WriteLine("------------------------");
				}
			}

			Console.Write("Для того, чтобы вернуться обратно нажмите любую клавишу...");
			Console.ReadLine();
		}

		public void GetTablesByLegs()
		{
			Console.WriteLine("------------------------");
			Console.Write("Введите кол-во ножек: ");
			int legs = int.Parse(Console.ReadLine());
			Console.WriteLine("------------------------");
			foreach (Table table in tables)
			{
				if (table.legs == legs)
				{
					Console.WriteLine("Тип: Стол");
					Console.WriteLine($"Наименование: {table.name}");
					Console.WriteLine($"Год производства: {table.city}");
					Console.WriteLine($"Стоимость: {table.cost}");
					Console.WriteLine($"Кол-во ножек: {table.legs}");
					Console.WriteLine($"Тип столешницы: {table.tabletopType}");
					Console.WriteLine("------------------------");
				}
			}

			Console.Write("Для того, чтобы вернуться обратно нажмите любую клавишу...");
			Console.ReadLine();
		}

		public void MainMenu()
		{
			while (true)
			{
				Console.Clear();
				Console.WriteLine("-- Главное меню --\n");
				Console.WriteLine($"Выбор операции:\n- Создание мебели (1)\n- Выбор мебели (2)\n- Выход из программы (q)");
				Console.Write("Выберите действие: ");
				string operation = Console.ReadLine();

				switch (operation)
				{
					case "1":
						FurnitureProccessCreation();
						break;
					case "2":
						SecondaryMenu();
						break;
					case "q":
						return;
					default:
						Console.Write("Неверная операция! Для того, чтобы вернуться обратно нажмите любую клавишу...");
						Console.ReadLine();
						break;
				}
			}
		}

		public void SecondaryMenu()
		{
			if (chairs.Count == 0 && tables.Count == 0)
			{
				Console.Clear();
				Console.WriteLine("-- Второе меню --\n");
				Console.Write("Мебель не создана! Для того, чтобы вернуться обратно нажмите любую клавишу...");
				Console.ReadLine();
				return;
			}
			bool isContinue = true;
			while (isContinue)
			{
				Console.Clear();
				Console.WriteLine("-- Второе меню --\n");
				Console.WriteLine($"Выбор операции:\n- Вывод мебели по городу производства (1)\n- Выбор стульев по количеству ножек (2)\n- Выбор столов по количеству ножек (3)\n- Выход в главное меню (q)");
				Console.Write("Выберите действие: ");
				string operation = Console.ReadLine();

				switch (operation)
				{
					case "1":
						GetFurnitureByCity();
						break;
					case "2":
						GetChairsByLegs();
						break;
					case "3":
						GetTablesByLegs();
						break;
					case "q":
						isContinue = false;
						break;
					default:
						Console.Write("Неверная операция! Для того, чтобы вернуться обратно нажмите любую клавишу...");
						Console.ReadLine();
						break;
				}
			}
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			RenderMenu menu = new RenderMenu();

			menu.MainMenu();
		}
	}
}
