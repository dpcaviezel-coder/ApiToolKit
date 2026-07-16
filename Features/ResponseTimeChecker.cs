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
            Console.Write("Enter a URL to test response time: ");
            string url = Console.ReadLine();

            using var client = new HttpClient();
            var stopwatch = new Stopwatch();

            try
            {
                stopwatch.Start();
                var response = await client.GetAsync(url);
                stopwatch.Stop();

                Console.WriteLine($"\nStatus: {response.StatusCode}");
                Console.WriteLine($"Response Time: {stopwatch.ElapsedMilliseconds} ms");

                // LOGGING
                Logger.Write($"TIME {url} → {stopwatch.ElapsedMilliseconds} ms");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }
    }
}
