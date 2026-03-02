using System;

namespace GenericDelegate
{
    // Custom Delegate
    delegate int MathOperation(int a, int b);

    // Generic Delegate
    delegate void GenericTwoParameterAction<TFirst, TSecond>(TFirst a, TSecond b);

    // Custom EventArgs
    public class OnClickEventArgs : EventArgs
    {
        public string ButtonName { get; set; }
    }

    // Publisher
    public class Button
    {
        public delegate void OnClickHandler();

        public event OnClickHandler OnClick;

        public void Click()
        {
            OnClick?.Invoke();
        }
    }

    class DelegatesDemoApp
    {
        // ================= HIGHER ORDER FUNCTION =================
        public void HigherOrderFunctionDemo()
        {
            var result = CalculateArea(AreaOfTriangle);
            Console.WriteLine($"Area: {result}");
        }

        int CalculateArea(Func<int, int, int> areaFunction)
        {
            return areaFunction(5, 10);
        }

        int AreaOfRectangle(int length, int width)
        {
            return length * width;
        }

        int AreaOfTriangle(int baseLength, int height)
        {
            return (baseLength * height) / 2;
        }

        // ================= LAMBDA EXPRESSION =================
        public void LambdaExpressionDemo()
        {
            Func<int, int> f;

            f = (int x) => x * x;

            var result = f(5);

            Console.WriteLine($"Result: {result}");
        }

        // ================= ANONYMOUS METHOD =================
        public void AnonymousMethodDemo()
        {
            MathOperation operation = delegate (int a, int b)
            {
                Console.WriteLine($"The sum of {a} and {b} is: {a + b}");
                return a + b;
            };

            operation(2, 3);
        }

        void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        // ================= MAIN DELEGATE DEMO =================
        public void Run()
        {
            Func<int, int, int> genericOperation = Add;

            Action<string> action = PrintMessage;
            action("Hello from Action delegate!");

            Predicate<int> predicate = IsEven;
            int testNumber = 4;

            Console.WriteLine($"Is {testNumber} even? {predicate(testNumber)}");

            Func<string, string, string> stringOperation = Concatenate;

            var x = stringOperation("Hello, ", "World!");
            Console.WriteLine($"Concatenation result: {x}");

            // Multicast Delegate
            genericOperation += Subtract;
            genericOperation += Multiply;
            genericOperation += Divide;

            genericOperation -= Subtract;

            var result = genericOperation(5, 3);

            Console.WriteLine($"Final result: {result}");
        }

        public string Concatenate(string a, string b)
        {
            string result = a + b;
            Console.WriteLine($"Concatenating '{a}' and '{b}' results in: '{result}'");
            return result;
        }

        public int Add(int a, int b)
        {
            Console.WriteLine($"The sum of {a} and {b} is: {a + b}");
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            Console.WriteLine($"The difference between {a} and {b} is: {a - b}");
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            Console.WriteLine($"The product of {a} and {b} is: {a * b}");
            return a * b;
        }

        public int Divide(int a, int b)
        {
            if (b != 0)
            {
                Console.WriteLine($"The quotient of {a} and {b} is: {a / b}");
                return a / b;
            }
            else
            {
                Console.WriteLine("Cannot divide by zero.");
            }

            return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DelegatesDemoApp app = new DelegatesDemoApp();

            app.Run();
            app.LambdaExpressionDemo();
            app.AnonymousMethodDemo();
            app.HigherOrderFunctionDemo();

            // ===== EVENT DEMO =====
            Button button = new Button();

            button.OnClick += () => Console.WriteLine("Bill Rings!");
            button.OnClick += () => Console.WriteLine("Charge for Electricity!");
            button.OnClick += () => Console.WriteLine("Third!");
            button.OnClick += () => Console.WriteLine("Fourth!");

            button.Click();
        }
    }
}
