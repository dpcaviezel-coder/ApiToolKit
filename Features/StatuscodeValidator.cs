using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiToolkit.Features
{
    public class StatusCodeValidator
    {
        public static async Task Run()
        {
            Console.Write("Enter a URL to test: ");
            string url = Console.ReadLine();

            Console.Write("Enter expected status code (e.g., 200): ");
            string expectedInput = Console.ReadLine();

            if (!int.TryParse(expectedInput, out int expectedStatus))
            {
                Console.WriteLine("Invalid status code.");
                return;
            }

            using var client = new HttpClient();

            try
            {
                var response = await client.GetAsync(url);
                int actualStatus = (int)response.StatusCode;

                Console.WriteLine($"\nExpected: {expectedStatus}");
                Console.WriteLine($"Actual:   {actualStatus}");

                if (actualStatus == expectedStatus)
                {
                    Console.WriteLine("\nResult: PASS");
                }
                else
                {
                    Console.WriteLine("\nResult: FAIL");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }
    }
}
