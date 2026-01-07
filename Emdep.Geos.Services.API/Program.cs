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
using Scalar.AspNetCore;
using Serilog;
using System.Data;
using System.IO.Compression;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting APM PROTOTYPE API...");

    var builder = WebApplication.CreateBuilder(args);

    // --- LOGGING ---
    builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services));

    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    builder.Services.AddProblemDetails();

    // --- CORS ---
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });

        options.AddPolicy("Production", policy =>
        {
            var origins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [];
            policy.WithOrigins(origins).AllowAnyMethod().AllowAnyHeader();
        });
    });

    // --- CONFIGURATION & MAPSTER ---
    builder.Services.Configure<APMSettings>(builder.Configuration.GetSection("APMSettings"));

    var mapsterConfig = new TypeAdapterConfig();

    var apmSettings = builder.Configuration.GetSection("APMSettings").Get<APMSettings>();

    if (apmSettings != null)
    {
        var mappingRegistration = new ActionPlanViewMapping(Options.Create(apmSettings));
        mappingRegistration.Register(mapsterConfig);
    }

    builder.Services.AddSingleton(mapsterConfig);

    builder.Services.AddScoped<IMapper, ServiceMapper>();

    // --- API VERSIONING ---
    builder.Services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(2690, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
    }).AddMvc();

    // --- COMPRESSION ---
    builder.Services.AddResponseCompression(options =>
    {
        options.EnableForHttps = true;
        options.Providers.Add<BrotliCompressionProvider>();
        options.Providers.Add<GzipCompressionProvider>();
    });

    builder.Services.Configure<BrotliCompressionProviderOptions>(options =>
    {
        options.Level = CompressionLevel.Fastest;
    });

    // --- DATABASE ---
    builder.Services.AddTransient<IDbConnection>(_ =>
    {
        var connectionString = builder.Configuration.GetConnectionString("MainServerWorkbenchContext");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("ConnectionString 'MainServerWorkbenchContext' not found or empty in appsettings.json");
        }
        return new MySqlConnection(connectionString);
    });

    builder.Services.AddScoped<IAPMRepository, APMRepository>();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();

    // --- OPENAPI / SCALAR ---
    builder.Services.AddOpenApi("v1", options =>
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

    var app = builder.Build();

    app.UseSerilogRequestLogging();
    app.UseExceptionHandler();

    if (app.Environment.IsDevelopment())
    {
        app.UseCors("AllowAll");
    }
    else
    {
        app.UseCors("Production");
    }

    app.MapOpenApi();

    app.MapScalarApiReference(options =>
    {
        options.WithOpenApiRoutePattern("/openapi/v1.json");
        options.Title = "APM PROTOTYPE API";
    });

    app.UseResponseCompression();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application failed to start unexpectedly.");
}
finally
{
    Log.CloseAndFlush();
}