namespace Sections;

public static class Section08_PatternMatching
{
    public static void Run()
    {
        object o = 5;

        if (o is int i)
            Console.WriteLine(i + 1);
    }
}
