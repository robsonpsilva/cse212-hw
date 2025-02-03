using System;
using System.Xml.XPath;

public class Program
{
    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.

        Console.WriteLine("Hello Sandbox World!");
        Sum sum = new Sum();
        int result = sum.CalculateSum(100, 1);
        Console.WriteLine(result);
    }
}