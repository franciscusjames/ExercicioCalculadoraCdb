using CalculadoraCdbApp.Apis.Cdb.Calcular;
using CalculadoraCdbApp.Apis.ForFrontend.Cdb.Calcular;
using CalculadoraCdbApp.Apis.Services;
using CalculadoraCdbApp.Apis.Shared;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CalculadoraCdbApp.Apis.DI;

public static class ApisServiceCollectionExtensions
{
    public static IServiceCollection AddForFrontendDependencies(this IServiceCollection services)
    {
        services.AddHandlers()
                .AddDomainServices()
                .AddMediatRWithBehaviors();

        return services;
    }

    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddScoped<AbstractValidator<CalculoCdbRequestDto>, CalculoCdbRequestDtoValidator>();

        return services;
    }

    public static IServiceCollection AddMediatRWithBehaviors(this IServiceCollection services)
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }

    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<ICalculadoraCdbService, CalculadoraCdbService>();

        return services;
    }
}
