
using System;
using System.Collections.Generic;

namespace ApiToolkit.Features
{
    public static class EnvironmentProfiles
    {
        public static Dictionary<string, ApiEnvironment> Profiles = new Dictionary<string, ApiEnvironment>
        {
            {
                "dev",
                new ApiEnvironment
                {
                    Name = "Development",
                    BaseUrl = "https://jsonplaceholder.typicode.com",
                    Token = null
                }
            },
            {
                "qa",
                new ApiEnvironment
                {
                    Name = "QA",
                    BaseUrl = "https://httpbin.org",
                    Token = null
                }
            },
            {
                "prod",
                new ApiEnvironment
                {
                    Name = "Production",
                    BaseUrl = "https://pokeapi.co/api/v2",
                    Token = null
                }
            }
        };

        public static ApiEnvironment Current { get; private set; }

        public static void SetEnvironment(string key)
        {
            if (Profiles.ContainsKey(key))
            {
                Current = Profiles[key];
                Console.WriteLine($"\nEnvironment set to: {Current.Name}");
                Logger.Write($"ENVIRONMENT CHANGED → {Current.Name}");
            }
            else
            {
                Console.WriteLine("Invalid environment key.");
            }
        }
    }

    public class ApiEnvironment
    {
        public string Name { get; set; }
        public string BaseUrl { get; set; }
        public string Token { get; set; }
    }
}
