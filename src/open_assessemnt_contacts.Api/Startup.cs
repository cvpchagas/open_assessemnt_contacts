using Open.Assessement.Contacts.Api.Utils.Middlewares;
using Open.Assessement.Contacts.Api.Utils.Providers;
using Open.Assessement.Contacts.Application.IoC;
using Open.Assessement.Contacts.Crosscutting.Enums;
using Open.Assessement.Contacts.Crosscutting.Extensions;
using Open.Assessement.Contacts.Crosscutting.Helpers.API;
using Open.Assessement.Contacts.Crosscutting.Utils.SystemConfiguration;
using Hangfire;
using Hangfire.Dashboard.BasicAuthorization;
using Hangfire.MemoryStorage;
using Hangfire.Oracle.Core;
using HttpClientService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Open.Assessement.Contacts.Api
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddResponseCompression(compression =>
            {
                compression.Providers.Add<BrotliCompressionProvider>();
            });


            services.AddDistributedMemoryCache();
            services.Configure<FormOptions>(x => x.ValueCountLimit = 1000000);

            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });

            services
                 .AddDependenciesInjection()
                 .AddHttpContextAccessor()
                 .AddControllers()
                 .AddNewtonsoftJson(options =>
                 {
                     options.SerializerSettings.Converters.Add(new StringEnumConverter());
                 });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "OA Operations API"
                });
            }).AddSwaggerGenNewtonsoftSupport();

            services
               .AddOptions<AOConfigApp>()
               .Bind(_configuration);
            services.AddHttpDependecy(_configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMiddleware<GCMiddleware>();

            loggerFactory.AddLog4Net();
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                if (Debugger.IsAttached)
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API v1");
                else
                    c.SwaggerEndpoint("/dmreportback/swagger/v1/swagger.json", "Web API v1");

            });

            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
