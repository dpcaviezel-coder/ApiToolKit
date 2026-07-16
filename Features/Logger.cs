using System;
using System.IO;

namespace ApiToolkit.Features
{
    public static class Logger
    {
        private static readonly string LogPath = "ApiToolkitLog.txt";

        public static void Write(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string entry = $"[{timestamp}] {message}";

            File.AppendAllText(LogPath, entry + Environment.NewLine);
        }
    }
}
