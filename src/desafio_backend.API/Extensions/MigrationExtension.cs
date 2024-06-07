using desafio_backend.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace desafio_backend.API.Extensions;

public static class MigrationExtension
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using DesafioDbContext context =
            scope.ServiceProvider.GetRequiredService<DesafioDbContext>();

        context.Database.Migrate();
    }
}