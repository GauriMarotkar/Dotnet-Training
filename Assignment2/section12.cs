namespace Sections;

public static class Section12_Loops
{
    public static void Run()
    {
        for (int i = 0; i < 3; i++)
            Console.WriteLine(i);

        foreach (var x in new[] { 10, 20, 30 })
            Console.WriteLine(x);
    }
}
