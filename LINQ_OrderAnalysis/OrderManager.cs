// OrderManager.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_OrderAnalysis
{
    public class OrderManager
    {
        private List<Order> orders = new List<Order>
        {
            new Order("Алексей", 15000m, new DateTime(2026, 10, 1)),
            new Order("Алексей", 25000m, new DateTime(2026, 10, 5)),
            new Order("Мария", 45000m, new DateTime(2026, 10, 2)),
            new Order("Мария", 10000m, new DateTime(2026, 10, 10)),
            new Order("Иван", 5000m, new DateTime(2026, 9, 15)),
            new Order("Иван", 30000m, new DateTime(2026, 10, 3)),
            new Order("Ольга", 60000m, new DateTime(2026, 10, 4)),
            new Order("Ольга", 12000m, new DateTime(2026, 10, 8)),
            new Order("Дмитрий", 8000m, new DateTime(2026, 10, 6)),
            new Order("Елена", 22000m, new DateTime(2026, 10, 7))
        };

        public void AnalyzeOrders(DateTime startDate, DateTime endDate)
        {
            var topClients = orders
                .Where(o => o.Date >= startDate && o.Date <= endDate)
                .GroupBy(o => o.ClientName)
                .Select(g => new { ClientName = g.Key, TotalSpent = g.Sum(o => o.Amount) })
                .OrderByDescending(x => x.TotalSpent)
                .Take(3);

            Console.WriteLine($"\nТоп-3 клиента за период с {startDate.ToShortDateString()} по {endDate.ToShortDateString()}:");
            foreach (var item in topClients)
            {
                Console.WriteLine($"Клиент: {item.ClientName} | Суммарные траты: {item.TotalSpent} руб.");
            }
        }

        public void AddOrder(Order order) => orders.Add(order);

        public void PrintAllOrders()
        {
            Console.WriteLine("=== Все заказы в базе ===");
            foreach (var order in orders) Console.WriteLine(order);
        }
    }
}