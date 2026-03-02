using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

using var context = new QuotationContext();

// JOIN using Navigation Properties
var result = context.QuotationItems
    .Include(qi => qi.Quotation)
        .ThenInclude(q => q.Customer)
    .Select(qi => new
    {
        CustomerName = qi.Quotation!.Customer!.Name,
        qi.Quotation.QuoteId,
        qi.Quotation.QuoteDate,
        qi.ProductName,
        qi.Quantity,
        qi.Price,
        LineTotal = qi.Quantity * qi.Price
    })
    .ToList();

foreach (var item in result)
{
    Console.WriteLine(
        $"Customer: {item.CustomerName}, " +
        $"QuoteId: {item.QuoteId}, " +
        $"Product: {item.ProductName}, " +
        $"Total: {item.LineTotal}"
    );
}

class QuotationContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Quotation> Quotations { get; set; }
    public DbSet<QuotationItem> QuotationItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=localhost\SQLEXPRESS;
              Database=QuotationDB;
              Trusted_Connection=True;
              TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().ToTable("Customer_Db");
        modelBuilder.Entity<Quotation>().ToTable("Quotations");
        modelBuilder.Entity<QuotationItem>().ToTable("QuotationItems");

        modelBuilder.Entity<Customer>()
            .HasKey(c => c.CustomerId);

        modelBuilder.Entity<Quotation>()
            .HasKey(q => q.QuoteId);

        modelBuilder.Entity<QuotationItem>()
            .HasKey(qi => qi.ItemId);

        modelBuilder.Entity<Quotation>()
            .HasOne(q => q.Customer)
            .WithMany(c => c.Quotations)
            .HasForeignKey(q => q.CustomerId);

        modelBuilder.Entity<QuotationItem>()
            .HasOne(qi => qi.Quotation)
            .WithMany(q => q.QuotationItems)
            .HasForeignKey(qi => qi.QuoteId);
    }
}

class Customer
{
    public int CustomerId { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }

    public ICollection<Quotation> Quotations { get; set; } = new List<Quotation>();
}

class Quotation
{
    public int QuoteId { get; set; }
    public int CustomerId { get; set; }
    public DateTime QuoteDate { get; set; }

    public Customer? Customer { get; set; }
    public ICollection<QuotationItem> QuotationItems { get; set; } = new List<QuotationItem>();
}

class QuotationItem   
{
    public int ItemId { get; set; }
    public int QuoteId { get; set; }
    public string? ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public Quotation? Quotation { get; set; }
}