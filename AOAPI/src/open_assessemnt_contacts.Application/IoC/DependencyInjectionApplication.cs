using Open.Assessement.Contacts.Application.Contracts;
using Open.Assessement.Contacts.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Open.Assessement.Contacts.Application.IoC
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddApplicationDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IContactApplication, ContactApplicationService>();
            services.AddTransient<ICountryApplication, CountryApplicationService>();
            services.AddTransient<IGenderApplication, GenderApplicationService>();
            return services;
        }
    }
}