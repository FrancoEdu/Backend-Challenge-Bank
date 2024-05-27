using AutoMapper;
using desafio_backend.Communication.Requests.User;
using desafio_backend.Communication.Response.User;
using desafio_backend.Domain;

namespace desafio_backend.Application.Mapper;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<UserRegisterRequestJson, User>();
    }

    private void EntityToResponse()
    {
        CreateMap<User, UserRegisterResponseJson>();
    }
}
