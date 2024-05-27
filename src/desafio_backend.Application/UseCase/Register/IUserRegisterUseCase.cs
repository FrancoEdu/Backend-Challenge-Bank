using desafio_backend.Communication.Requests.User;
using desafio_backend.Communication.Response.User;

namespace desafio_backend.Application.UseCase.Register;
public interface IUserRegisterUseCase
{
    public Task<UserRegisterResponseJson> Execute(UserRegisterRequestJson request);

}
