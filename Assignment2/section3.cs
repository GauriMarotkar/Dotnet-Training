namespace Sections;

public static class Section03_PrimitiveTypes
{
    public static void Run()
    {
        int a = 42;
        long big = 3_000_000_000L;
        float f = 3.14f;
        double d = 2.71828;
        decimal money = 19.99m;
        bool ok = true;
        char letter = 'A';

        Console.WriteLine($"{a} {big} {f} {d} {money} {ok} {letter}");
    }
}
