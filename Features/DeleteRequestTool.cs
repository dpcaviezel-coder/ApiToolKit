using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiToolkit.Features
{
    public class DeleteRequestTool
    {
        public static async Task Run()
        {
            Console.Write("Enter a URL path (example: /posts/1): ");
            string path = Console.ReadLine();

            string fullUrl = EnvironmentProfiles.Current != null
                ? EnvironmentProfiles.Current.BaseUrl + path
                : path;

            using var client = new HttpClient();
            HeaderManager.ApplyHeaders(client);

            try
            {
                var response = await client.DeleteAsync(fullUrl);
                var content = await response.Content.ReadAsStringAsync();

                content = JsonFormatter.TryFormat(content);
                ResponseSaver.LastResponse = content;

                Console.WriteLine($"\nStatus: {response.StatusCode}");
                Console.WriteLine("\nResponse:");
                Console.WriteLine(content);

                // QA rule: DELETE must return 200 or 204
                int code = (int)response.StatusCode;
                if (code == 200 || code == 204)
                    StatusBadge.SetPass();
                else
                    StatusBadge.SetFail();

                Logger.Write($"DELETE {fullUrl} → {response.StatusCode}");
            }
            catch (Exception ex)
            {
                StatusBadge.SetFail();
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }
    }
}
