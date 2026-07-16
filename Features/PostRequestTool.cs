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
            Console.Write("Enter a URL path (example: /posts): ");
            string path = Console.ReadLine();

            string fullUrl = EnvironmentProfiles.Current != null
                ? EnvironmentProfiles.Current.BaseUrl + path
                : path;

            Console.WriteLine("\nEnter JSON body (single line):");
            string jsonBody = Console.ReadLine();

            using var client = new HttpClient();
            HeaderManager.ApplyHeaders(client);

            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(fullUrl, content);
                var responseBody = await response.Content.ReadAsStringAsync();

                responseBody = JsonFormatter.TryFormat(responseBody);
                ResponseSaver.LastResponse = responseBody;

                Console.WriteLine($"\nStatus: {response.StatusCode}");
                Console.WriteLine("\nResponse:");
                Console.WriteLine(responseBody);

                // QA rule: POST must return 201
                if ((int)response.StatusCode == 201)
                    StatusBadge.SetPass();
                else
                    StatusBadge.SetFail();

                Logger.Write($"POST {fullUrl} → {response.StatusCode}");
            }
            catch (Exception ex)
            {
                StatusBadge.SetFail();
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }
    }
}
