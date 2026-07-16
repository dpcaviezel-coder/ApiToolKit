using System;
using System.Collections.Generic;

namespace ApiToolkit.Features
{
    public static class HeaderManager
    {
        private static readonly Dictionary<string, string> Headers = new Dictionary<string, string>();

        public static void AddHeader(string key, string value)
        {
            Headers[key] = value;
            Console.WriteLine($"\nHeader added: {key}: {value}");
            Logger.Write($"HEADER ADDED → {key}: {value}");
        }

        public static void RemoveHeader(string key)
        {
            if (Headers.Remove(key))
            {
                Console.WriteLine($"\nHeader removed: {key}");
                Logger.Write($"HEADER REMOVED → {key}");
            }
            else
            {
                Console.WriteLine("\nHeader not found.");
            }
        }

        public static void ShowHeaders()
        {
            Console.WriteLine("\nCurrent Headers:");

            if (Headers.Count == 0)
            {
                Console.WriteLine("(none)");
                return;
            }

            foreach (var h in Headers)
                Console.WriteLine($"{h.Key}: {h.Value}");
        }

        public static void ApplyHeaders(System.Net.Http.HttpClient client)
        {
            foreach (var h in Headers)
                client.DefaultRequestHeaders.Add(h.Key, h.Value);
        }
    }
}
