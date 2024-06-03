using System.Net;

namespace desafio_backend.Exception.ExceptionBase;
public class NotAllowedTransferException : DesafioBackendException
{
    public override int StatusCode => (int)HttpStatusCode.MethodNotAllowed;
    public override List<string> GetErrors()
    {
        return new List<string>() { Message };
    }

    public NotAllowedTransferException(string errorMessage) : base(errorMessage) { }
}

