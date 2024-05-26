using System.Net;

namespace desafio_backend.Exception.ExceptionBase;
public class UnauthorizedTransferException : DesafioBackendException
{
    public override int StatusCode => (int)HttpStatusCode.Unauthorized;
    public override List<string> GetErrors()
    {
        return new List<string>() { Message };
    }

    public UnauthorizedTransferException(string errorMessage) : base(errorMessage) { }
}
