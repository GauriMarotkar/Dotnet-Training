// See https://aka.ms/new-console-template for more information
using System;
namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            CollectionClassesDemo();
            CollectionClassesDemo2();
        }
        public static void CollectionClassesDemo()
        {
            List<string> list = new List<string>();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Add("4");
            System.Console.WriteLine(list.Count);

            foreach (var item in list)
            {
                System.Console.WriteLine(item);
            }
        }
        public static void CollectionClassesDemo2()
        {

            List<int> marks = new List<int>(10);
            marks.Add(1);
            marks.Add(1);
            Console.WriteLine($"Count: {marks.Count}, Capacity: {marks.Capacity}");

            marks.AddRange(new int[] { 1, 2, 3 });
            Console.WriteLine($"Count: {marks.Count}, Capacity: {marks.Capacity}");

            marks.AddRange(new int[] { 4, 5, 6 });
            Console.WriteLine($"Count: {marks.Count}, Capacity: {marks.Capacity}");

            Console.WriteLine($"Matks Avg:{marks.Average()}");
        }
    }
}
