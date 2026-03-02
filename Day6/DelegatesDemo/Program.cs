using System;

namespace DelegatesDemo;

class Program
{
    static void Main(string[] args)
    {
        DelegatesDemoApp app = new DelegatesDemoApp();
        app.Run();
    }
}

class DelegatesDemoApp
{
    delegate void MathOperation(int a, int b);

    public void Run()
    {
        MathOperation operation = Add;

        // Multicast Delegate
        operation += Subtract;
        operation += Multiply;
        operation += Divide;

        operation -= Subtract;

        operation(5, 3);

        Console.WriteLine("All operations executed");
    }

    public void Add(int a, int b)
    {
        Console.WriteLine($"The sum of {a} and {b} is: {a + b}");
    }

    public void Subtract(int a, int b)
    {
        Console.WriteLine($"The difference between {a} and {b} is: {a - b}");
    }

    public void Multiply(int a, int b)
    {
        Console.WriteLine($"The multiplication of {a} and {b} is: {a * b}");
    }

    public void Divide(int a, int b)
    {
        Console.WriteLine($"The division of {a} and {b} is: {a / b}");
    }
}
