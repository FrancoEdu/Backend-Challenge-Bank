namespace desafio_backend.Domain;

public interface IUnitOfWork
{
  Task Commit();
}
