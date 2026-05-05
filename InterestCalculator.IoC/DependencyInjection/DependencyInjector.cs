using InterestCalculator.IoC.DependencyInjection.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InterestCalculator.IoC.DependencyInjection;

public static class DependencyInjector
{
    public static Task InjectDependencies(IServiceCollection services, IConfiguration configuration)
    {
        DomainInjector.InjectDomain(services, configuration);
        return Task.CompletedTask;
    }
}