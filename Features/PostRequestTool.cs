using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiToolkit.Features
{
    public class PostRequestTool
    {
        public static async Task Run()
        {
            Console.Write("Enter a URL to POST to: ");
            string url = Console.ReadLine();

            Console.WriteLine("\nEnter JSON body (single line):");
            string jsonBody = Console.ReadLine();

            using var client = new HttpClient();

            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(url, content);
                var responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"\nStatus: {response.StatusCode}");
                Console.WriteLine("\nResponse:");
                Console.WriteLine(responseBody);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }
    }
}
