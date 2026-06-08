using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Organizer.Application.Profiles;
using Organizer.Application.Services;
using Organizer.Domain.Interfaces;
using Organizer.Infra.Data.Context;
using Organizer.Infra.Data.Identity;
using Organizer.Infra.Data.Repository;

namespace Organizer.Infra.IoC;

public static class DependencyInjectionAPI
{
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContextPool<OrganizerContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("OrganizerConnect"),
                b => b.MigrationsAssembly(typeof(OrganizerContext).Assembly.FullName)));
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<OrganizerContext>()
            .AddDefaultTokenProviders();
        services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Account/Login");
        services.AddScoped<IAuthenticate, AuthenticateService>();
        services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
        //Caso Precise Mudar Futuramente só implementar Services especializadas.
        services.AddScoped<ITarefaService, TarefaService>();
        services.AddScoped<IListaService, ListaService>();
        services.AddScoped<ITarefaRepository, TarefasRepository>();
        services.AddScoped<IListaRepository, ListaRepository>();
        services.AddAutoMapper(cfg => { }, typeof(DomainProfile));
        return services;
    }
}