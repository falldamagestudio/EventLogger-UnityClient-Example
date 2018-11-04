public static class LogSession
{
    public static EventLogger.Session session;

    public static void Log(string type, object data)
    {
        if (session != null)
            session.SubmitEvent(type, data);
    }
}
