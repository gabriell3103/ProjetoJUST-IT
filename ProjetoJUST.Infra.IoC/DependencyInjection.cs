using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoJUST.Application.Mappings;
using ProjetoJUST.Application.Services;
using ProjetoJUST.Application.Services.Interfaces;
using ProjetoJUST.Domain.Authentication;
using ProjetoJUST.Domain.Repositories;
using ProjetoJUST.Infra.Data.Authenticator;
using ProjetoJUST.Infra.Data.Context;
using ProjetoJUST.Infra.Data.Repositories;

namespace ProjetoJUST.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
            c => c.MigrationsAssembly(("ProjetoJUST.Api"))));
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITokenGenerator, TokenGenerator>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        
        return services;
    }

    public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(DomainToDtoMappings));
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        return services;
    }
}