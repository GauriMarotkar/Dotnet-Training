namespace MethodsDemo
{
    public class ParametersDemo
    {
        // Optional & Named Parameters
        public void Configure(int timeout = 30, bool verbose = false)
        {
            Console.WriteLine($"Timeout: {timeout}");
            Console.WriteLine($"Verbose: {verbose}");
        }

        // out parameter
        public void SetCount(out int count)
        {
            count = 42; // must be assigned
        }

        // params keyword
        public int Sum(params int[] numbers)
        {
            int total = 0;
            foreach (int n in numbers)
            {
                total += n;
            }
            return total;
        }

        // Method Overloading
        public void Log(string message)
        {
            Console.WriteLine($"Message: {message}");
        }

        public void Log(string message, int level)
        {
            Console.WriteLine($"Message: {message}, Level: {level}");
        }
    }
}