namespace desafio_backend.Exception.ExceptionBase;
public abstract class DesafioBackendException : SystemException
{
    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();

    protected DesafioBackendException(string message) : base(message) { }
}