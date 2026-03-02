using System;

public class Program
{
    public static void Main()
    {
        try
        {
            First();
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        }
        // Generic Exceptions towards the end
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            Console.WriteLine($"Inner Exception: {ex.InnerException}");
        }
        finally
        {
            // house keeping
            Console.WriteLine("finally.");
        }

        Console.WriteLine("Program continues after handling the exception.");
    }

    static void First()
    {
        Second();
    }

    static void Second()
    {
        try
        {
            Third();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception From Third: {ex.Message}");

            // Good rethrow
            // throw;

            // Bad rethrow
            // throw ex;

            // Wrapping exception (current active code)
            throw new Exception("My Exception here", ex);
        }
    }

    static void Third()
    {
        var numerator = 10;
        var denominator = 0;

        var result = numerator / denominator;
    }

    static void AcceptPayment(decimal amount, decimal balance)
    {
        if (amount > balance)
        {
            throw new NotEnoughBalanceException("Not enough balance to complete the payment.");
        }

        Console.WriteLine("Payment accepted.");
    }
}

class BankException : ApplicationException
{
    public BankException(string message) : base(message)
    {
    }

    public BankException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}

class NotEnoughBalanceException : BankException
{
    public NotEnoughBalanceException(string message)
        : base(message)
    {
    }

    public NotEnoughBalanceException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}