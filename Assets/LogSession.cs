public static class LogSession
{
    public static EventLogger.Session session;

    public static void LogJsonData(string type, string jsonData)
    {
        if (session != null)
            session.LogJsonData(type, jsonData);
    }

    public static void LogSerializableObject(string type, object data)
    {
        if (session != null)
            session.LogSerializableObject(type, data);
    }
}
