namespace Sections;

public static class Section07_Conditionals
{
    public static void Run()
    {
        int x = 5;

        string result = x switch
        {
            0 => "zero",
            > 0 => "positive",
            _ => "negative"
        };

        Console.WriteLine(result);
    }
}
