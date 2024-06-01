namespace desafio_backend.Communication.Environment;
public class AuthorizeMock
{
    private readonly string _AUTHORIZE_MOCK_ENDPOINT = "https://util.devi.tools/api/v2/authorize";

    public string GetAuthorizeMockEndpoint()
    {
        return _AUTHORIZE_MOCK_ENDPOINT;
    }
}
