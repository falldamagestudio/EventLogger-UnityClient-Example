public static class LogSession
{
    public static EventLogger.Session session;

    public static void Log(string type)
    {
        if (session != null)
            session.Log(type);
    }

    public static void Log(string type, string jsonData)
    {
        if (session != null)
            session.Log(type, jsonData);
    }

    public static void Log<LogEventType>(LogEventType logEvent) where LogEventType : EventLogger.LogEvent
    {
        if (session != null)
            session.Log(logEvent);
    }
}
