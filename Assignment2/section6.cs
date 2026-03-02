namespace Sections;

public static class Section06_Nullables
{
    public static void Run()
    {
        int? n = null;
        int value = n ?? -1;

        Console.WriteLine(value);
    }
}
