using System.Net;

namespace desafio_backend.Exception.ExceptionBase;
public class EmailAlreadyExistsException : DesafioBackendException
{
    public override int StatusCode => (int)HttpStatusCode.NotFound;
    public override List<string> GetErrors()
    {
        return new List<string>() { Message };
    }

    public EmailAlreadyExistsException(string errorMessage) : base(errorMessage) { }
}
