// Задание 1

using System;

public delegate void Controller();

namespace lab
{
    class MyEvent
    {
        public event Controller CrossBorderEvent;
        public bool IsTriggered { get; private set; } = false;

        public void CrossedBorder()
        {
            if (CrossBorderEvent != null)
            {
                CrossBorderEvent();
            }
        }

        public void Trigger()
        {
            IsTriggered = true;
        }
    }

    class StartPoint
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public StartPoint(int posX, int posY)
        {
            this.PosX = posX;
            this.PosY = posY;
        }
    }

    class PossibleEvents
    {
        static void CheckBorders(int currentX, int currentY, int[] borderX, int[] borderY, MyEvent boundaryEvent)
        {
            if (currentX < borderX[0] || currentX > borderX[1] || currentY < borderY[0] || currentY > borderY[1])
            {
                Console.WriteLine("Выход за границы.");
                boundaryEvent.Trigger();
            }
        }

        static void Main()
        {
            StartPoint position = new StartPoint(100, 50);
            int[] borderX = { 0, 450 };
            int[] borderY = { 0, 200 };
            Random randomGen = new Random();
            MyEvent boundaryEvent = new MyEvent();
            boundaryEvent.CrossBorderEvent += () => CheckBorders(position.PosX, position.PosY, borderX, borderY, boundaryEvent);

            while (!boundaryEvent.IsTriggered)
            {
                position.PosX += randomGen.Next(-100, 100);
                position.PosY += randomGen.Next(-100, 100);

                Console.WriteLine($"Координаты: x = {position.PosX}, y = {position.PosY}");
                boundaryEvent.CrossedBorder();
            }
        }
    }
}


//Задание 2

using System;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;

public delegate void Race();

namespace lab_22_03
{
    class MyEvent
    {
        public event Race CrossFinish;
        public bool IsTriggered { get; private set; } = false;

        public void Crossed()
        {
            if (CrossFinish != null)
            {
                CrossFinish();
            }
        }

        public void Triggered()
        {
            IsTriggered = true;
        }
    }

    class Horse
    {
        public string Name { get; set; }
        public int Distance { get; set; }
        public int Speed { get; set; }

        public Horse(string name, int distance, int speed)
        {
            this.Name = name;
            this.Distance = distance;
            this.Speed = speed;
        }
    }

    class PossibleEvents
    {
        static void Finish(int timeInterval, int finishLine, Horse horse1, Horse horse2, Horse horse3, MyEvent raceEvent)
        {
            if (horse1.Distance >= finishLine) 
            {
                Console.WriteLine($"Лошадь {horse1.Name} выиграла!");
                raceEvent.Triggered();
            }
            else if (horse2.Distance >= finishLine)
            {
                Console.WriteLine($"Лошадь {horse2.Name} выиграла!");
                raceEvent.Triggered();
            }
            else if (horse3.Distance >= finishLine)
            {
                Console.WriteLine($"Лошадь {horse3.Name} выиграла!");
                raceEvent.Triggered();
            }
        }

        static void Main()
        {
            Horse horse_1 = new Horse("Бурёнка", 0, 10);
            Horse horse_2 = new Horse("Ксюха", 0, 8);
            Horse horse_3 = new Horse("Молния Маккуин", 0, 9);
            Random rndm = new Random();
            MyEvent evt = new MyEvent();
            int finishLineDistance = 200;
            int t = 2;
            evt.CrossFinish += () => Finish(t, finishLineDistance, horse_1, horse_2, horse_3, evt);

            while (!evt.EventTriggered)
            {
                horse_1.Distance += t * horse_1.Speed;
                horse_1.Speed = rndm.Next(0, 60);
                horse_2.Distance += t * horse_2.Speed;
                horse_2.Speed = rndm.Next(0, 60);
                horse_3.Distance += t * horse_3.Speed;
                horse_3.Speed = rndm.Next(0, 60);

                Console.WriteLine($"Лошадка {horse_1.Name} прошла: {horse_1.Distance}");
                Console.WriteLine($"Лошадка {horse_2.Name} прошла: {horse_2.Distance}");
                Console.WriteLine($"Лошадка {horse_3.Name} прошла: {horse_3.Distance}");
                evt.Crossed();
            }
        }
    }
}
