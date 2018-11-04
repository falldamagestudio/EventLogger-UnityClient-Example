using UnityEngine;

public class LogSessionInitializer : MonoBehaviour {

    private EventLogger.EventTransmitter transmitter;
    private EventLogger.Session session;

    public bool LogToBackend = true;
    public EventLogger.BackendTransmitter.Configuration BackendTransmitterConfig;
    public bool LogToDisk = true;
    public EventLogger.DiskLogger.Configuration DiskLoggerConfig;

    void Awake()
    {
        transmitter = new EventLogger.EventTransmitter(LogToBackend ? BackendTransmitterConfig : null, LogToDisk ? DiskLoggerConfig : null);

        string sessionId = EventLogger.Session.GetNewSessionId();

        session = new EventLogger.Session(sessionId, transmitter);
        session.Begin();

        LogSession.session = session;
    }

    void Update()
    {
        transmitter.Update(Time.deltaTime);
    }

    void OnDestroy()
    {
        LogSession.session = null;

        session.End();
        transmitter.Flush();
    }
}
