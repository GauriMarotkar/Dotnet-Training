namespace MethodsDemo
{
    public class Student
    {
        public static int StudentCount = 0;

        public string Name { get; set; }
        public int Age { get; set; }

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
            StudentCount++;
        }

        public void Print()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Count: {StudentCount}");
        }

        // Optional parameter
        public int DoubleAge(int multiplyBy = 2)
        {
            return Age * multiplyBy;
        }
    }
}