using Open.Assessement.Contacts.Domain.Contracts.Services;
using Open.Assessement.Contacts.Domain.Entities;
using Open.Assessement.Contacts.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Open.Assessement.Contacts.Application.IoC
{
    public static class DependencyInjectionDomainServices
    {
        public static IServiceCollection AddDomainServicesDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IContactDomainService, ContactDomainService>();
            services.AddTransient<ICountryDomainService, CountryDomainService>();
            services.AddTransient<IGenderDomainService, GenderDomainService>();
            return services;
        }
    }
}