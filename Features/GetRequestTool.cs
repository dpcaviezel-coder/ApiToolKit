
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

                content = JsonFormatter.TryFormat(content);
                ResponseSaver.LastResponse = content;

                Console.WriteLine($"\nStatus: {response.StatusCode}");
                Console.WriteLine("\nResponse:");
                Console.WriteLine(content);

                // QA rule: GET must return 200
                if ((int)response.StatusCode == 200)
                    StatusBadge.SetPass();
                else
                    StatusBadge.SetFail();

                Logger.Write($"GET {fullUrl} → {response.StatusCode}");
            }
            catch (Exception ex)
            {
                StatusBadge.SetFail();
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }
    }
}

