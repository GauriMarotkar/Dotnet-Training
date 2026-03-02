using System;
using System.Collections.Generic;
using System.Linq;

class Customer
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
}

class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public decimal OrderAmount { get; set; }
}

public class LinqDemo
{
    public void Run()
    {
        // Customers list
        var customers = new List<Customer>
        {
            new Customer { CustomerId = 1, CustomerName = "Alice" },
            new Customer { CustomerId = 2, CustomerName = "Bob" },
            new Customer { CustomerId = 3, CustomerName = "Charlie" }
        };

        // Orders list
        var orders = new List<Order>
        {
            new Order { OrderId = 101, CustomerId = 1, OrderAmount = 2500 },
            new Order { OrderId = 102, CustomerId = 1, OrderAmount = 1500 },
            new Order { OrderId = 103, CustomerId = 2, OrderAmount = 3000 },
            new Order { OrderId = 104, CustomerId = 2, OrderAmount = 2000 }
        };

        // Join customers and orders
        var customerOrders =
            from c in customers
            join o in orders
            on c.CustomerId equals o.CustomerId
            select new
            {
                c.CustomerName,
                o.OrderId,
                o.OrderAmount
            };

        Console.WriteLine("Customer Orders:");
        foreach (var item in customerOrders)
        {
            Console.WriteLine($"{item.CustomerName} placed Order {item.OrderId} of amount {item.OrderAmount}");
        }

        // Number of orders per customer
        var orderCount =
            from c in customers
            join o in orders
            on c.CustomerId equals o.CustomerId
            group o by c.CustomerName into g
            select new
            {
                CustomerName = g.Key,
                OrderCount = g.Count()
            };

        Console.WriteLine("\nOrder Count Per Customer:");
        foreach (var item in orderCount)
        {
            Console.WriteLine($"{item.CustomerName} placed {item.OrderCount} orders");
        }

        // Total order value per customer
        var totalOrderValue =
            from c in customers
            join o in orders
            on c.CustomerId equals o.CustomerId
            group o by c.CustomerName into g
            select new
            {
                CustomerName = g.Key,
                TotalAmount = g.Sum(x => x.OrderAmount)
            };

        Console.WriteLine("\nTotal Order Value Per Customer:");
        foreach (var item in totalOrderValue)
        {
            Console.WriteLine($"{item.CustomerName} total value is {item.TotalAmount}");
        }
    }
}