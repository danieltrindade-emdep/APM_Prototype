using Asp.Versioning;
using Emdep.Geos.API.Middleware;
using Emdep.Geos.Core.Interfaces;
using Emdep.Geos.Infrastructure.Repositories;
using Emdep.Geos.Services.API.Configuration;
using Emdep.Geos.Services.API.Mapping;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Options;
using MySqlConnector;
using System.Data;
using System.IO.Compression;

namespace Emdep.Geos.Services.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDbConnection>(_ =>
            {
                var connectionString = configuration.GetConnectionString("MainServerWorkbenchContext");
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("ConnectionString 'MainServerWorkbenchContext' not found in configuration.");
                }
                return new MySqlConnection(connectionString);
            });

            services.AddScoped<IAPMRepository, APMRepository>();

            return services;
        }

        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<APMSettings>(configuration.GetSection("APMSettings"));

            var mapsterConfig = new TypeAdapterConfig();
            var apmSettings = configuration.GetSection("APMSettings").Get<APMSettings>();

            if (apmSettings != null)
            {
                var mappingRegistration = new ActionPlanViewMapping(Options.Create(apmSettings));
                mappingRegistration.Register(mapsterConfig);
            }

            services.AddSingleton(mapsterConfig);
            services.AddScoped<IMapper, ServiceMapper>();

            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();

            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(2690, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            }).AddMvc();

            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
            });

            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });

                options.AddPolicy("Production", policy =>
                {
                    var origins = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [];
                    policy.WithOrigins(origins).AllowAnyMethod().AllowAnyHeader();
                });
            });

            return services;
        }

        public static IServiceCollection AddDocumentation(this IServiceCollection services)
        {
            services.AddOpenApi("v1", options =>
            {
                options.AddSchemaTransformer((schema, context, cancellationToken) =>
                {
                    if (context.JsonTypeInfo.Type.FullName != null &&
                       (context.JsonTypeInfo.Type.FullName.StartsWith("System.Text.RegularExpressions") ||
                        context.JsonTypeInfo.Type.FullName.Contains("ValueSpan")))
                    {
                        schema.Type = "string";
                        schema.Properties = null;
                    }
                    return Task.CompletedTask;
                });
            });

            return services;
        }
    }
}
