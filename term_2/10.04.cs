using System;
using System.Collections.Generic;

struct Book
{
    public string Author;
    public string Title;
    public int Copyright;
    public string Publisher;
    public bool EverLended;
    public bool OnHands;
    public string? LendBook;
    public string? RetutnBook;

    public Book(string a, string t, int c, string p, bool e, bool o)
    {
        this.Author = a;
        this.Title = t;
        this.Copyright = c;
        this.Publisher = p;
        this.EverLended = e;
        this.OnHands = o;
        this.LendBook = null;
        this.RetutnBook = null;
    }

    public void IsGiven(string l, string r)
    {
        if (EverLended)
        {
            this.LendBook = l;
            this.RetutnBook = r;
        }
        else
        {
            this.LendBook = null;
            this.RetutnBook = null;
        }
    }
}

class Program
{
    static void Main()
    {
        List<Book> AllBooks = new List<Book> {
            new Book("Маргарет Этвуд","Рассказ служанки", 2018, "Pocketbook", false, false),
            new Book("Вильям Шекспир", "Гамлет", 2012, "Wordsworth", true, false),
            new Book("Юзуки Асако", "Масло", 2023, "Рипол Классик", true, true)
            new Book("Мария Корелли", "Скорбь сатаны", 2000, "Магистраль", false, false)
        };

        var book1 = AllBooks[1];
        book1.IsGiven("Была выдана: 31.08.2078", "Была сдана 10.09.2078");
        AllBooks[1] = book1;

        var book2 = AllBooks[2];
        book2.IsGiven("Была выдана: 22.05.2025", "Была сдана 11.10.2025");
        AllBooks[2] = book2;

        List<Book> LendedBooks = new List<Book>();
        List<Book> NeverLendedBooks = new List<Book>();

        for (int i = 0; i < AllBooks.Count; i++)
        {
            if (AllBooks[i].OnHands) LendedBooks.Add(AllBooks[i]);
            if (!AllBooks[i].EverLended) NeverLendedBooks.Add(AllBooks[i]);
        }

        Console.WriteLine("Книги, которые сейчас на руках: ");
        for (int i = 0; i < LendedBooks.Count; i++)
        {
            Console.WriteLine($"Книга: {LendedBooks[i].Title}\nАвтор: {LendedBooks[i].Author}\nгод издания: {LendedBooks[i].Copyright}\n" +
                $"Издательство: {LendedBooks[i].Publisher}");
            Console.WriteLine($"{LendedBooks[i].LendBook}\n{LendedBooks[i].RetutnBook}\n");
        }

        Console.WriteLine("Книги, которые никогда не брали: ");
        for (int i = 0; i < NeverLendedBooks.Count; i++)
        {
            Console.WriteLine($"Книга: {NeverLendedBooks[i].Title}\nАвтор: {NeverLendedBooks[i].Author}\nгод издания: {NeverLendedBooks[i].Copyright}\n" +
                $"Издательство: {NeverLendedBooks[i].Publisher}\n");
        }
    }
}
