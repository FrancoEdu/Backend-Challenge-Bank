using System.Net;

namespace desafio_backend.Exception.ExceptionBase;
public class UnavailableServiceNotifyException : DesafioBackendException
{
    public override int StatusCode => (int)HttpStatusCode.ServiceUnavailable;
    public override List<string> GetErrors()
    {
        return new List<string>() { Message };
    }

    public UnavailableServiceNotifyException(string errorMessage) : base(errorMessage) { }
}
