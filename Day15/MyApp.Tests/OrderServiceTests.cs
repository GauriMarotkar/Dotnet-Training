namespace MyApp.Tests;

// Moq
public class MockOrderRepository : IOrderRepository
{
    public void Save(Order order)
    {
        Console.WriteLine($"Saved Order to Database {order.ToString()}");
    }
}

public class MockEmailSender : IEmailSender
{
    public void Send(string email, string message)
    {
        Console.WriteLine($"Email sent to {email}: {message}");
    }
}

public class OrderServiceTests : IDisposable
{
    IOrderRepository _repository;
    IEmailSender _emailSender;
    OrderService _sut;
    public OrderServiceTests()
    {
        // Setup
        _repository = new MockOrderRepository();
        _emailSender = new MockEmailSender();
        _sut = new OrderService(_repository, _emailSender);
    }

    public void Dispose()
    {
        // Teardown
    }

    // ClassName_MethodName_ExpectedBehavior

    [Fact]
    public void OrderService_PlaceOrder_SavesOrderAndSendsEmail()
    {
        // Arrange
        var expectedResult = 10;

        // Act
        var actualResult = _sut.PlaceOrder(new Order { Email = "john.doe@Orderscompany.com"});

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }
}