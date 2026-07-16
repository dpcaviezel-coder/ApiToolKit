using System;
using System.Text.Json;

namespace ApiToolkit.Features
{
    public static class JsonFormatter
    {
        public static string TryFormat(string raw)
        {
            try
            {
                using var doc = JsonDocument.Parse(raw);
                return JsonSerializer.Serialize(doc, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            }
            catch
            {
                // Not valid JSON — return raw text
                return raw;
            }
        }
    }
}
