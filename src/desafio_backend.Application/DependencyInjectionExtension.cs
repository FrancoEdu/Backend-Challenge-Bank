using desafio_backend.Application.Mapper;
using desafio_backend.Application.UseCase.Register;
using Microsoft.Extensions.DependencyInjection;

namespace desafio_backend.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
        AddMapping(services);
    }

    private static void AddMapping(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        #region User useCases
        
        services.AddScoped<IUserRegisterUseCase, UserRegisterUseCase>();

        #endregion User useCases
    }
}
