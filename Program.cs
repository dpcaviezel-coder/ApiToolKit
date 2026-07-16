using System;
using System.IO;
using System.Threading.Tasks;
using ApiToolkit.Features;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("API Toolkit");
        Console.WriteLine("1. GET Request");
        Console.WriteLine("2. POST Request");
        Console.WriteLine("3. Status Code Validator");
        Console.WriteLine("4. Response Time Checker");
        Console.WriteLine("5. View Log File");
        Console.WriteLine("6. Change Environment");

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

            case "3":
                await StatusCodeValidator.Run();
                break;

            case "4":
                await ResponseTimeChecker.Run();
                break;

            case "5":
                Console.WriteLine("\n--- Log File ---\n");
                if (File.Exists("ApiToolkitLog.txt"))
                    Console.WriteLine(File.ReadAllText("ApiToolkitLog.txt"));
                else
                    Console.WriteLine("Log file is empty.");
                break;

            case "6":
                Console.WriteLine("\nChoose environment:");
                Console.WriteLine("dev");
                Console.WriteLine("qa");
                Console.WriteLine("prod");
                Console.Write("Enter key: ");

                string env = Console.ReadLine();
                EnvironmentProfiles.SetEnvironment(env);
                break;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
}

