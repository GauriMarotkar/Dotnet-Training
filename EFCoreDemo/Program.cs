// using Microsoft.Data.SqlClient;


// string query = "SELECT * FROM Employees WHERE Salary > 50000";
// SqlConnection connection = new SqlConnection("YourConnectionStringHere");
// SqlCommand cmd = new SqlCommand(query, connection);
// SqlDataReader reader = cmd.ExecuteReader();
// List<Employee> employees = new List<Employee>();
// while (reader.Read())
// {
//     employees.Add(new Employee { Name = (string)reader["Name"], Salary = (decimal)reader["Salary"] });
// }


// class Employee
// {
//     public string Name { get; set; }
//     public decimal Salary { get; set; }
// }

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

CrmContext _context = new CrmContext();

var customers = _context.Customers
    .Where(e => e.Age > 20)
    .ToList();

// Without ToList()
// Console.WriteLine("customers.GetType(): " + customers.GetType());
// Console.WriteLine($"Query: {customers.ToQueryString()}");

// With ToList()
// Console.WriteLine("customers.GetType(): " + customers.GetType());

// With AsEnumerable()
// Console.WriteLine("customers.GetType(): " + customers.GetType());

customers.Add(new Customer { Id = 4,Name = "John Doe", Age = 30 });
_context.SaveChanges();

Console.WriteLine($"Customers Count: {customers.Count()}");

// customers.Add(new Customer { Name = "Danny Lee", Age = 30 });
// _context.SaveChanges();

// Because DbSet is not IList, index operator will not work
// var first = _context.Customers[0];

var Sneha = _context.Customers.FirstOrDefault(c => c.Name == "Sneha");
if (Sneha != null) Sneha.Age = 31;

_context.SaveChanges();

foreach (var customer in customers)
{
    Console.WriteLine($"Id: {customer.Id} Customer: {customer.Name}, Age: {customer.Age}");
}

class CrmContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Server=localhost;Database=CrmDb;User Id=sa;Password=p@ssw0rd;TrustServerCertificate=True");
        optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CrmDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");

        // optionsBuilder.UseMySQL("YourConnectionStringHere");
        // optionsBuilder.UsePostgreql("YourConnectionStringHere");
    }
}

public class Order
{
    [Key]
    public int OrderId { get; set; }

    [Required]
    [MaxLength(100)]
    [MinLength(3)]
    public required string Product { get; set; }

    [Required]
    [Precision(18, 2)]
    public decimal Price { get; set; }

    [ForeignKey("CustomerId")]
    public int CustomerId { get; set; }
    public required Customer Customer { get; set; }
}

public class Customer
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required int Age { get; set; }
}