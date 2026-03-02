using System.Linq;

namespace Sections;

public static class Section11_Collections
{
    public static void Run()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };

        var evens = list.Where(i => i % 2 == 0);

        Console.WriteLine(string.Join(",", evens));
    }
}
