using Application.Security.Tokens.Implementation;
using Application.Security.Tokens.Interfaces;
using Application.Services.Implementation;
using Application.Services.Interfaces;
using Application.Validation.Game;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MPS.Domain.Modules.SecurityModules.PasswordModule.Implementation;
using MPS.Domain.Modules.SecurityModules.PasswordModule.Interfaces;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddMediatR(typeof(IAssemblyMarker));
        collection.AddScoped<IAuthService, AuthService>();
        collection.AddScoped<IPasswordManager, Sha256PasswordManager>();
        collection.AddScoped<ITokenManager, JwtTokenManager>();
        collection.AddValidatorsFromAssemblyContaining<SetPlayerOneValidator>();
        
        return collection;
    }
}