public class OrderService
{
    private readonly IOrderRepository _repository;  // ← real database
    private readonly IEmailSender _emailSender;    // ← real SMTP server

    public OrderService(IOrderRepository repository, IEmailSender emailSender)
    {
        _repository = repository;
        _emailSender = emailSender;
    }

    public int PlaceOrder(Order order)
    {

        // if(order.Data > 5PM)
        //     throw new Exception("Its too late come toorrow");
        _repository.Save(order);                              // hits the DB
        _emailSender.Send(order.Email, "Order confirmed");    // sends real
        //  email
        return 10;
    }
}

// Refactoring
public interface IOrderRepository
{
    void Save(Order order);
}

public class SqlOrderRepository : IOrderRepository
{
    public void Save(Order order)
    {
        // Code to save the order to a SQL database
    }
}

public interface IEmailSender
{
    void Send(string email, string message);
}

public class SmtpEmailSender : IEmailSender
{
    public void Send(string email, string message)
    {}
}

public class Order
{
    public  required string Email { get; set; }
}