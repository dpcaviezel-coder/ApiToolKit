using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiToolkit.Features
{
    public class StatusCodeValidator
    {
        public static async Task Run()
        {
            Console.Write("Enter a URL path (example: /users/1): ");
            string path = Console.ReadLine();

            string fullUrl = EnvironmentProfiles.Current != null
                ? EnvironmentProfiles.Current.BaseUrl + path
                : path;

            Console.Write("Enter expected status code (e.g., 200): ");
            string expectedInput = Console.ReadLine();

            if (!int.TryParse(expectedInput, out int expectedStatus))
            {
                Console.WriteLine("Invalid status code.");
                StatusBadge.SetFail();
                return;
            }

            using var client = new HttpClient();
            HeaderManager.ApplyHeaders(client);

            try
            {
                var response = await client.GetAsync(fullUrl);
                int actualStatus = (int)response.StatusCode;

                Console.WriteLine($"\nExpected: {expectedStatus}");
                Console.WriteLine($"Actual:   {actualStatus}");

                if (actualStatus == expectedStatus)
                {
                    Console.WriteLine("\nResult: PASS");
                    StatusBadge.SetPass();
                }
                else
                {
                    Console.WriteLine("\nResult: FAIL");
                    StatusBadge.SetFail();
                }

                Logger.Write($"VALIDATE {fullUrl} → Expected {expectedStatus}, Actual {actualStatus}");
            }
            catch (Exception ex)
            {
                StatusBadge.SetFail();
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }
    }
}

