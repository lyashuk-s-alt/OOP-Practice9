using System;

namespace Rozumatic_OOP_Practice9
{
    // ==========================================================================
    // КЛАС POINT З ПЕРЕВАНТАЖЕННЯМ ОПЕРАТОРІВ
    // Загальне завдання: оператори +, ==, !=
    // Домашнє завдання: оператор * (множення на скаляр)
    // ==========================================================================
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        // 1. ЗАГАЛЬНЕ ЗАВДАННЯ: Перевантаження бінарного оператора + (додавання координат)
        public static Point operator +(Point p1, Point p2)
        {
            if (p1 == null || p2 == null) throw new ArgumentNullException("Точки не можуть бути null!");
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        // 2. ЗАГАЛЬНЕ ЗАВДАННЯ: Перевантаження оператора порівняння == (еквівалентність точок)
        public static bool operator ==(Point p1, Point p2)
        {
            // Перевірка на null для уникнення нескінченної рекурсії
            if (ReferenceEquals(p1, p2)) return true;
            if (p1 is null || p2 is null) return false;

            return p1.X == p2.X && p1.Y == p2.Y;
        }

        // 3. ЗАГАЛЬНЕ ЗАВДАННЯ: Перевантаження оператора порівняння != (обов'язкова пара для ==)
        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1 == p2);
        }

        // 4. ДОМАШНЄ ЗАВДАННЯ: Перевантаження оператора * (множення координат на скалярне число)
        public static Point operator *(Point p, double scalar)
        {
            if (p == null) throw new ArgumentNullException("Точка не може бути null!");
            return new Point(p.X * scalar, p.Y * scalar);
        }

        // Перевизначення Equals та GetHashCode (гарна практика при перевантаженні ==)
        public override bool Equals(object? obj)
        {
            if (obj is Point otherPoint) return this == otherPoint;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public void PrintInfo(string label)
        {
            Console.WriteLine($"{label}: ({X}; {Y})");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine("  РОЗУМАТИК // ПРАКТИЧНЕ ЗАНЯТТЯ №9: ПЕРЕВАНТАЖЕННЯ ОПЕРАТОРІВ");
            Console.WriteLine("==========================================================================");

            // Створення тестових точок
            Point p1 = new Point(3.5, 4.0);
            Point p2 = new Point(1.5, -2.5);
            Point p3 = new Point(3.5, 4.0);

            Console.WriteLine("\n--- Початкові точки ---");
            p1.PrintInfo("Точка P1");
            p2.PrintInfo("Точка P2");
            p3.PrintInfo("Точка P3");

            // 1. Тест оператора + (Загальне завдання)
            Console.WriteLine("\n--- Тестування оператора + (Додавання точок P1 + P2) ---");
            Point sumResult = p1 + p2;
            sumResult.PrintInfo("Результат P1 + P2");

            // 2. Тест операторів == та != (Загальне завдання)
            Console.WriteLine("\n--- Тестування операторів порівняння (== та !=) ---");
            Console.WriteLine($"Чи рівні P1 та P3 (однакові координати)? -> {p1 == p3} (Очікувано: True)");
            Console.WriteLine($"Чи рівні P1 та P2 (різні координати)?    -> {p1 == p2} (Очікувано: False)");
            Console.WriteLine($"Чи не рівні P1 та P2?                    -> {p1 != p2} (Очікувано: True)");

            // 3. Тест оператора * (Домашнє завдання)
            Console.WriteLine("\n--- Тестування оператора * (Множення точки P1 на скаляр 2) ---");
            double scalar = 2.0;
            Point mulResult = p1 * scalar;
            mulResult.PrintInfo($"Результат P1 * {scalar}");

            Console.WriteLine("\n✅ Практичне заняття №9 успішно виконано!");
        }
    }
}
