
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiToolkit.Features
{
    public class ResponseTimeChecker
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

            var stopwatch = new Stopwatch();

            try
            {
                stopwatch.Start();
                var response = await client.GetAsync(fullUrl);
                stopwatch.Stop();

                Console.WriteLine($"\nStatus: {response.StatusCode}");
                Console.WriteLine($"Response Time: {stopwatch.ElapsedMilliseconds} ms");

                Logger.Write($"TIME {fullUrl} → {stopwatch.ElapsedMilliseconds} ms");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }
    }
}
