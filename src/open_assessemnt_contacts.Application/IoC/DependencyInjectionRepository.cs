using Open.Assessement.Contacts.Domain.Contracts.Repositories;
using Open.Assessement.Contacts.Infra.Repositories.Json;
using Microsoft.Extensions.DependencyInjection;

namespace Open.Assessement.Contacts.Application.IoC
{
    public static class DependencyInjectionRepository
    {
        public static IServiceCollection AddRepositoryDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            return services;
        }
    }
}