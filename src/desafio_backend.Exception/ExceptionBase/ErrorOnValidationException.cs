using System.Net;

namespace desafio_backend.Exception.ExceptionBase;
public class ErrorOnValidationException : DesafioBackendException
{
    private readonly List<string> _errors;

    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public ErrorOnValidationException(List<string> errorMessage) : base(string.Empty)
    {
        _errors = errorMessage;
    }

    public override List<string> GetErrors()
    {
        return _errors;
    }
}
