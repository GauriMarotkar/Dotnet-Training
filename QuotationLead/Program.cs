using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace QuotationManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new QuotationContext();

            // Query all leads
            var leads = context.Leads.ToList();

            foreach (var lead in leads)
            {
                Console.WriteLine($"Id: {lead.LeadId}, Name: {lead.Name}, Email: {lead.Email}, Phone: {lead.Phone}");
            }
        }
    }

    public class QuotationContext : DbContext
    {
        public DbSet<Lead> Leads { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Adjust server name if needed (localhost or localhost\SQLEXPRESS)
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=LeadDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");
        }
    }

    public class Lead
    {
        [Key]
        public int LeadId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
