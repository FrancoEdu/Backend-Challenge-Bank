namespace desafio_backend.Communication.Response.Integration;
public class AuthorizeMockResponse
{
    public string Status { get; set; } = string.Empty;
    public AuthorizeDataMockResponse Data { get; set; } = new AuthorizeDataMockResponse();
}
