// Order.cs
using System;

namespace LINQ_OrderAnalysis
{
    public class Order
    {
        public string ClientName { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Order(string clientName, decimal amount, DateTime date)
        {
            ClientName = clientName;
            Amount = amount;
            Date = date;
        }

        public override string ToString()
        {
            return $"Клиент: {ClientName}, Сумма: {Amount} руб., Дата: {Date.ToShortDateString()}";
        }
    }
}