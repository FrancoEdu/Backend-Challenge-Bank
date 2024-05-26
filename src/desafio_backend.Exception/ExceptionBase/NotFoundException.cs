using System.Net;

namespace desafio_backend.Exception.ExceptionBase;
public class NotFoundException : DesafioBackendException
{
    public override int StatusCode => (int)HttpStatusCode.NotFound;
    public override List<string> GetErrors()
    {
        return new List<string>() { Message };
    }

    public NotFoundException(string errorMessage) : base(errorMessage) { }
}
