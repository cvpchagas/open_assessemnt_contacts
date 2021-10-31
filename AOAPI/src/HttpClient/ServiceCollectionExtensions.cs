
using Open.Assessement.Contacts.Crosscutting.Handler;
using HttpClientService.Interfaces;
using HttpClientService.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;


namespace HttpClientService
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHttpDependecy(this IServiceCollection services, IConfiguration configuration)

        {
            return services;
        }


    }
}
