namespace desafio_backend.Communication.Environment;
public class NotifyMock
{
    private readonly string _NOTIFY_ENDPOINT = "https://util.devi.tools/api/v1/notify";

    public string GetNotifyMockEndpoint()
    {
        return _NOTIFY_ENDPOINT;
    }
}
