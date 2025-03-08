using System;
namespace Laboratornaya
{
    class Name {
        public string _name {get;set;}
        public Name (string name)
        {
            _name = name;
        }
    }
     public interface IQuantities
    {
        void Area();
        void Per();
    }
    class Circle: Name, IQuantities
    {
        public int _r;
        public int area1;
        public int per1;
        public Circle (string name, int r): base (name)
        {
            this._r=r;
        }
        public void Area()
        {
            area1 = _r *_r;
            Console.WriteLine($"Площадь окружности = {area1}");
        }
        public void Per()
        {
            per1 = 2*_r;
            Console.WriteLine($"Периметр окружности = {per1}");
        }
    }
    class Square: Name, IQuantities
    {
        public int _n;
        public int area2;
        public int per2;
        public Square(string name,int n): base (name)
        {
            this._n = n;
        }
        public void Area()
        {
            area2 = _n *_n;
            Console.WriteLine($"Площадь квадрата = {area2}");
        }
        public void Per()
        {
            per2 = 4 * _n;
            Console.WriteLine($"Периметр квадрата = {per2}");
        }
    }
    class Triangle: Name, IQuantities
    {
        public double _m;
        public double area3;
        public double per3;
        public Triangle (string name, double m): base (name)
        {
            this._m = m;
        }
        public void Area()
        {
            area3 = (Math.Sqrt(3) * _m * _m) / 4;
            Console.WriteLine($"Площадь равностороннего треугольника = {area3}");
        }
        public void Per()
        {
            per3 = _m * 3;
            Console.WriteLine($"Периметр равностороннего треугольника = {per3}");
        }
    }
  class Program
    {
        static void Main()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Введите название фигуры: ");
                string line = Console.ReadLine();

                if (line == "Окружность")
                {
                    Name cr = new Name(line);
                    Console.WriteLine("Введите радиус: ");
                    int rr = Convert.ToInt32(Console.ReadLine());
                    Circle circle = new Circle(line, rr);
                    circle.Area();
                    circle.Per();
                }
                 else if (line == "Квадрат")
                    
                {
                    Name sqr = new Name(line);
                    Console.WriteLine("Введите длину стороны: ");
                    int a = Convert.ToInt32(Console.ReadLine());
                    Square sqare = new Square(line, a);
                    sqare.Area();
                    sqare.Per();


                }
                else if (line == "Равносторонний треугольник")
                {
                    Name trg = new Name(line);   
                    Console.WriteLine("Введите длину стороны: ");
                    int b = Convert.ToInt32(Console.ReadLine());
                    Triangle triangle = new Triangle(line, b);
                    triangle.Area();
                    triangle.Per();
                }
                else
                {
                    Console.WriteLine("Ошибка");
                }
            }
        }
    }
}

