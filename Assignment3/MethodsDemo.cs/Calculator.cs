namespace MethodsDemo
{
    public class Calculator
    {
        int a, b;

        public Calculator(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        // Instance method
        public int Add()
        {
            return a + b;
        }

        // Static method
        public static int Add(int x, int y)
        {
            return x + y;
        }
    }
}