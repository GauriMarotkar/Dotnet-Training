public class ExpressionBodiedMembersDemo
{
    public class Demo
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        // expression-bodied
        public int Subtract(int a, int b) => a - b;

        public int Multiply(int a, int b) => a * b;
    }
}