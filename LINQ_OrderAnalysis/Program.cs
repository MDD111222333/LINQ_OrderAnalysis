// Program.cs
using System;

namespace LINQ_OrderAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderManager manager = new OrderManager();
            manager.PrintAllOrders();
            manager.AnalyzeOrders(new DateTime(2026, 10, 1), new DateTime(2026, 10, 31));

            while (true)
            {
                try
                {
                    Console.WriteLine("\n1. Анализ за период\n2. Добавить заказ\n3. Показать все\nВыбор (или 'stop'): ");
                    string? choice = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(choice) || choice.Trim().ToLower() == "stop") break;

                    if (choice == "1")
                    {
                        Console.Write("Начальная дата (гггг-мм-дд): ");
                        DateTime s = DateTime.Parse(Console.ReadLine() ?? "2026-10-01");
                        Console.Write("Конечная дата (гггг-мм-дд): ");
                        DateTime e = DateTime.Parse(Console.ReadLine() ?? "2026-10-31");
                        manager.AnalyzeOrders(s, e);
                    }
                    else if (choice == "2")
                    {
                        Console.Write("Имя клиента: ");
                        string name = Console.ReadLine() ?? string.Empty;
                        Console.Write("Сумма: ");
                        decimal amount = decimal.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Дата (гггг-мм-дд): ");
                        DateTime date = DateTime.Parse(Console.ReadLine() ?? "2026-10-01");
                        if (!string.IsNullOrWhiteSpace(name))
                        {
                            manager.AddOrder(new Order(name, amount, date));
                            Console.WriteLine("Заказ добавлен.");
                        }
                    }
                    else if (choice == "3")
                    {
                        manager.PrintAllOrders();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}