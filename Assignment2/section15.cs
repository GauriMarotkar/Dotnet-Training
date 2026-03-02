namespace Sections;

public static class Section15_Debugging
{
    public static void Run()
    {
        int a = 5;
        int b = 0;

        try
        {
            int c = a / b;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
