using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.Write("Enter a URL to GET: ");
        string url = Console.ReadLine();

        using var client = new HttpClient();

        try
        {
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"\nStatus: {response.StatusCode}");
            Console.WriteLine("\nResponse:");
            Console.WriteLine(content);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }
    }
}
