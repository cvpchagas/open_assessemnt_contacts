using Microsoft.Extensions.DependencyInjection;

namespace Open.Assessement.Contacts.Application.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependenciesInjection(this IServiceCollection services)
        {
            services.AddApplicationDependencyInjection();
            services.AddDomainServicesDependencyInjection();
            services.AddRepositoryDependencyInjection();

            return services;
        }
    }
}
