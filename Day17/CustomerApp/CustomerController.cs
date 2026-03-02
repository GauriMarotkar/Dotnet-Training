// using Microsoft.AspNetCore.Mvc;
// using CustomerApp.DTOs;

// [ApiController]
// [Route("api/v1/[controller]")]
// public class CustomerController : ControllerBase
// {
//     [HttpGet]
//     public IActionResult GetAllCustomers()
//     {
//         return Ok(new List<string> { "Alice", "Bob", "Charlie" });
//     }

//     [HttpGet("{id:int}")]
//     public IActionResult GetCustomerById(int id)
//     {
//         return Ok("Alice");
//     }

//     // [HttpPost] 
//     // public IActionResult AddCustomer([FromBody] CustomerDTO dto)
//     // {
//     //     _service.Add(customer);
//     //     return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
//     // } 

//     [HttpPost]
// public async Task<IActionResult> AddCustomer([FromBody] CustomerDTO dto)
// {
//     var created = await _service.CreateCustomerAsync(dto);
//     return CreatedAtAction(nameof(GetCustomerById), new { id = created.Id }, created);
// }

//     [HttpDelete("{id:int}")]
//     public IActionResult DeleteCustomer(int id)
//     { 
//         var deleted = _service.Delete(id); 
//         if (!deleted) return NotFound();
//          return NoContent();
//     }
// }

using Microsoft.AspNetCore.Mvc;
using CustomerApp.DTOs;

[ApiController]
[Route("api/v1/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;   // ✅ declare the service

    // ✅ inject the service via constructor
    public CustomerController(ICustomerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customers = await _service.GetAllCustomersAsync();
        return Ok(customers);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var customer = await _service.GetCustomerByIdAsync(id);
        if (customer == null) return NotFound();
        return Ok(customer);
    }

    [HttpPost] 
    public async Task<IActionResult> AddCustomer([FromBody] CustomerDTO dto)
    {
        var created = await _service.CreateCustomerAsync(dto);   
        return CreatedAtAction(nameof(GetCustomerById), new { id = created.Id }, created);
    } 

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    { 
        var deleted = await _service.DeleteCustomerAsync(id);   
        if (!deleted) return NotFound();
        return NoContent();
    }

    [HttpGet("search")] 
    public IActionResult SearchCustomer([FromQuery] string name) 
    { 
        return Ok($"You searched for {name}"); 
    }

    [HttpPost] 
    public async Task<IActionResult> AddCustomer([FromBody] CustomerDTO dto) 
    { 
        var created = await _service.CreateCustomerAsync(dto); 
        return CreatedAtAction(nameof(GetCustomerById), 
        new { id = created.Id }, 
        created); 
    }

}
