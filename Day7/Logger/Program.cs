using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

var services = new ServiceCollection();

// Configure Logging Services
services.AddLogging(config =>
{
    
    config.AddSerilog(new LoggerConfiguration()
        .WriteTo.Console()            
        .MinimumLevel.Debug()         
        .CreateLogger(), dispose: true);

    // Add default console logging
    config.AddConsole();

  
    config.SetMinimumLevel(LogLevel.Debug);
});


services.AddScoped<UserService>();

// Build the Service Provider
var serviceProvider = services.BuildServiceProvider();


var userService = serviceProvider.GetService<UserService>();

// Call method to create user
userService?.CreateUser("John");


// UserService class
public class UserService
{
    // ILogger injected using Dependency Injection
    private readonly ILogger<UserService> _logger;
    public UserService(ILogger<UserService> logger)
    {
        _logger = logger;
    }

    public void CreateUser(string name)
    {
        // Information log before starting user creation
        _logger.LogInformation("Creating user: {Name}", name);

        try
        {
            
            _logger.LogInformation("User {Name} created successfully", name);
        }
        catch (Exception ex)
        {
            // Logging error with exception details
            _logger.LogError(ex, "Failed to create user: {Name}", name);
        }
    }
}