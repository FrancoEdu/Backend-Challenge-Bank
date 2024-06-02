using desafio_backend.Application.Integration.Refit;
using desafio_backend.Application.Integration.UseCase;
using desafio_backend.Application.Mapper;
using desafio_backend.Application.UseCase.Auth;
using desafio_backend.Application.UseCase.Register;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace desafio_backend.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
        AddMapping(services);
        AddRefitClient(services);
    }

    private static void AddMapping(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {        
        services.AddScoped<IUserRegisterUseCase, UserRegisterUseCase>();
        services.AddScoped<IAuthUseCase, AuthUseCase>();

        services.AddScoped<IAuthorizeIntegration, AuthorizeIntegration>();
        services.AddScoped<INotifyIntegration, NotifyIntegration>();
    }

    private static void AddRefitClient(IServiceCollection services)
    {
        services.AddRefitClient<IAuthorizeRefit>().ConfigureHttpClient(c =>
        {
            c.BaseAddress = new Uri("https://util.devi.tools/api");
        });
        
        services.AddRefitClient<INotifyRefit>().ConfigureHttpClient(c =>
        {
            c.BaseAddress = new Uri("https://util.devi.tools/api");
        });
    }
}
