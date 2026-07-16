
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiToolkit.Features
{
    public class GetRequestTool
    {
        public static async Task Run()
        {
            Console.Write("Enter a URL path (example: /users/1): ");
            string path = Console.ReadLine();

            string fullUrl = EnvironmentProfiles.Current != null
                ? EnvironmentProfiles.Current.BaseUrl + path
                : path;

            using var client = new HttpClient();
            HeaderManager.ApplyHeaders(client);

            try
            {
                var response = await client.GetAsync(fullUrl);
                var content = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"\nStatus: {response.StatusCode}");
                Console.WriteLine("\nResponse:");
                Console.WriteLine(content);

                Logger.Write($"GET {fullUrl} → {response.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }
    }
}

