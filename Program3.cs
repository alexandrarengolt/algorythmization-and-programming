// See https://aka.ms/new-console-template for more information
string l = Console.ReadLine();
if (l == "")
{
	Console.WriteLine("Пустая строка");
	return;
}

Stack<char> stack = new Stack<char>();
foreach (char c in l)
{
	if (c == '(' || c == '[' || c == '{')
	{
		stack.Push(c);
		
	}
	else if (c == ')' || c == ']' || c == '}')
	{
		if (stack.Count == 0) 
		{
			Console.WriteLine("В стеке ничего нет");
			return;
		}

		char s = stack.Pop();
		if ((s == '(' && c != ')') || (s == '[' && c != ']') || (s == '{' && c != '}'))
		{
			Console.WriteLine("Скобки расставлены неверно");
			return;
		}
	}
}

if (stack.Count != 0) 
{
	Console.WriteLine("Скобки расставлены неверно");
}
else
{
	Console.WriteLine("Скобки расставлены верно");
}