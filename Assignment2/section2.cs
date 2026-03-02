namespace Sections;

public static class Section02_ProgramStructure
{
    public static void Run()
    {
        string[] args = { "Revature" };
        Console.WriteLine(args.Length > 0 ? args[0] : "No args");
    }
}
