// using Microsoft.Extensions.Logging;
// using CustomerApp.DTOs;

// public class CustomerDTO
// {
//     public int Id { get; set; }
//     public required string Name { get; set; }

//     public required string Email { get; set; }

// }

// public interface ICustomerService
// {
//     Task<List<CustomerDTO>> GetAllCustomersAsync();
//     Task<CustomerDTO> GetCustomerByIdAsync(int id);
//     // Task CreateCustomerAsync(CreateCustomerDTO dto);
//     Task<CustomerDTO> CreateCustomerAsync(CustomerDTO dto);
//     Task<bool> DeleteCustomerAsync(int id);
// }

// // Services/CustomerService.cs
// public class CustomerService : ICustomerService
// {
//     private readonly ILogger<CustomerService> _logger;
//     private readonly List<CustomerDTO> _customers = new();
//     public CustomerService(ILogger<CustomerService> logger)
//     {
//         _logger = logger;
//         _customers.Add(new CustomerDTO { Id = 1, Name = "Acme Corp", Email = "contact@acme.com" });
//         _customers.Add(new CustomerDTO { Id = 2, Name = "TechStart Inc", Email = "info@techstart.com" });
//     }

//     public async Task<List<CustomerDTO>> GetAllCustomersAsync()
//     {
//         _logger.LogInformation("Fetching all customers");
//         // Simulated data
//         return new List<CustomerDTO>
//         {
//             new CustomerDTO { Id = 1, Name = "Acme Corp", Email = "contact@acme.com" },
//             new CustomerDTO { Id = 2, Name = "TechStart Inc", Email = "info@techstart.com" }
//         };
//     }

//     public async Task<CustomerDTO> GetCustomerByIdAsync(int id)
//     {
//         _logger.LogInformation($"Fetching customer {id}");
//         return new CustomerDTO { Id = id, Name = "Sample Company", Email = "company@email.com" };
//     }

//     public async Task<CustomerDTO> CreateCustomerAsync(CustomerDTO dto)
//     {
//         _logger.LogInformation($"Creating customer {dto.Name}");
//         dto.Id = _customers.Count > 0 ? _customers.Max(c => c.Id) + 1 : 1; 
//         _customers.Add(dto);
//         return dto;
//     } 
//     public async Task<bool> DeleteCustomerAsync(int id)
//     {
//         _logger.LogInformation($"Deleting customer {id}");
//         var customer = _customers.FirstOrDefault(c => c.Id == id);
//         if (customer == null) return false;
//         _customers.Remove(customer);
//         return true;
//     }
// }

using CustomerApp.DTOs;

public interface ICustomerService
{
    Task<List<CustomerDTO>> GetAllCustomersAsync();
    Task<CustomerDTO?> GetCustomerByIdAsync(int id);
    Task<CustomerDTO> CreateCustomerAsync(CustomerDTO dto);
    Task<bool> DeleteCustomerAsync(int id);
}

public class CustomerService : ICustomerService
{
    private readonly List<CustomerDTO> _customers = new();

    public CustomerService()
    {
        _customers.Add(new CustomerDTO { Id = 1, Name = "Alice", Email = "alice@email.com" });
        _customers.Add(new CustomerDTO { Id = 2, Name = "Bob", Email = "bob@email.com" });
    }

    public async Task<List<CustomerDTO>> GetAllCustomersAsync() => _customers;

    public async Task<CustomerDTO?> GetCustomerByIdAsync(int id) =>
        _customers.FirstOrDefault(c => c.Id == id);

    public async Task<CustomerDTO> CreateCustomerAsync(CustomerDTO dto)
    {
        dto.Id = _customers.Count > 0 ? _customers.Max(c => c.Id) + 1 : 1;
        _customers.Add(dto);
        return dto;
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == id);
        if (customer == null) return false;
        _customers.Remove(customer);
        return true;
    }
}
