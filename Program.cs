using System;
using System.Threading.Tasks;
using ApiToolkit.Features;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("API Toolkit");
        Console.WriteLine("1. GET Request");
        Console.WriteLine("2. POST Request");
        Console.Write("Choose an option: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                await GetRequestTool.Run();
                break;

            case "2":
                await PostRequestTool.Run();
                break;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
}


