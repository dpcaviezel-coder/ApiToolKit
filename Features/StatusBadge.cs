namespace ApiToolkit.Features
{
    public static class StatusBadge
    {
        public static string LastStatus { get; private set; } = "(none)";

        public static void SetPass()
        {
            LastStatus = "PASS";
        }

        public static void SetFail()
        {
            LastStatus = "FAIL";
        }
    }
}
