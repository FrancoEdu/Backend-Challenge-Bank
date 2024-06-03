using System.Net;

namespace desafio_backend.Exception.ExceptionBase;
public class InsufficientBalanceException : DesafioBackendException
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;
    public override List<string> GetErrors()
    {
        return new List<string>() { Message };
    }

    public InsufficientBalanceException(string errorMessage) : base(errorMessage) { }
}
