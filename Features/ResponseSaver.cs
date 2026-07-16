using System;
using System.IO;

namespace ApiToolkit.Features
{
    public static class ResponseSaver
    {
        public static string LastResponse { get; set; }

        public static void Save()
        {
            if (string.IsNullOrWhiteSpace(LastResponse))
            {
                Console.WriteLine("\nNo response available to save.");
                return;
            }

            Directory.CreateDirectory("SavedResponses");

            string fileName = $"response_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.json";
            string fullPath = Path.Combine("SavedResponses", fileName);

            File.WriteAllText(fullPath, LastResponse);

            Console.WriteLine($"\nSaved to: {fullPath}");
            Logger.Write($"RESPONSE SAVED → {fileName}");
        }
    }
}
