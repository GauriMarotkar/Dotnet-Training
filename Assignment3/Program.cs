using System;
using MethodsDemo;
using EmployeeDemo;
using ExtensionMethodsDemo;

namespace DAY_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Assignment 3 : Methods & Members ===\n");

            ParametersDemoTest();
            StudentDemoTest();
            CalculatorDemoTest();
            ExtensionMethodDemoTest();
            ExpressionBodiedDemoTest();
        }

        static void ParametersDemoTest()
        {
            Console.WriteLine("-- Parameters Demo --");

            ParametersDemo demo = new ParametersDemo();

            // Optional & named parameters
            demo.Configure();
            demo.Configure(verbose: true, timeout: 60);

            // out parameter
            demo.SetCount(out int count);
            Console.WriteLine("Out count value: " + count);

            // params keyword
            int sum = demo.Sum(1, 2, 3, 4, 5);
            Console.WriteLine("Sum using params: " + sum);

            // Method overloading
            demo.Log("Hello");
            demo.Log("Hello", 2);

            Console.WriteLine();
        }

        static void StudentDemoTest()
        {
            Console.WriteLine("-- Student Demo --");

            Student s1 = new Student("Alice", 20);
            s1.Print();

            Student s2 = new Student("Bob", 22);
            s2.Print();

            Console.WriteLine("Double Age: " + s1.DoubleAge());

            Console.WriteLine();
        }

        static void CalculatorDemoTest()
        {
            Console.WriteLine("-- Calculator Demo --");

            Calculator calc = new Calculator(10, 20);
            Console.WriteLine("Instance Add: " + calc.Add());

            Console.WriteLine("Static Add: " + Calculator.Add(5, 6));

            Console.WriteLine();
        }

        static void ExtensionMethodDemoTest()
        {
            Console.WriteLine("-- Extension Method Demo --");

            Employee emp = new Employee(1, "Dave", "Smith", 30);
            emp.Print();

            emp.DoubleTheAge();
            emp.Print();

            Console.WriteLine();
        }

        static void ExpressionBodiedDemoTest()
        {
            Console.WriteLine("-- Expression Bodied Members Demo --");

            ExpressionBodiedMembersDemo.Demo demo =
                new ExpressionBodiedMembersDemo.Demo();

            Console.WriteLine("Add: " + demo.Add(2, 3));
            Console.WriteLine("Subtract: " + demo.Subtract(5, 2));
            Console.WriteLine("Multiply: " + demo.Multiply(3, 4));

            Console.WriteLine();
        }
    }
}
