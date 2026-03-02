using System.Text;

namespace Sections;

public static class Section04_Strings
{
    public static void Run()
    {
        string s = "Hello" + " World";

        var sb = new StringBuilder();
        sb.Append("Line1 ").Append("Line2");

        Console.WriteLine(s);
        Console.WriteLine(sb.ToString());
    }
}
