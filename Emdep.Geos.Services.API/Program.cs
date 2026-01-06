using Asp.Versioning;
using Emdep.Geos.API.Middleware;
using Emdep.Geos.Core.Interfaces;
using Emdep.Geos.Infrastructure.Repositories;
using Emdep.Geos.Services.API.Configuration;
using Mapster;
using Microsoft.AspNetCore.ResponseCompression;
using MySqlConnector;
using Scalar.AspNetCore;
using Serilog;
using System.Data;
using System.IO.Compression;
using System.Reflection;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting APM PROTOTYPE API...");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services));

    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    builder.Services.AddProblemDetails();

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
    });

    TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

    builder.Services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(2690, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
    }).AddMvc();

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



    builder.Services.AddTransient<IDbConnection>(_ =>
        new MySqlConnection(builder.Configuration.GetConnectionString("WorkbenchContext")));

    builder.Services.AddScoped<IAPMRepository, APMRepository>();

    var apmSettings = builder.Configuration.GetSection("APMSettings").Get<APMSettings>();

    if (apmSettings?.Images != null)
    {
        GlobalSettings.EmployeesRoundedUrl = apmSettings.Images.BaseUrlRounded;
        GlobalSettings.EmployeesNormalUrl = apmSettings.Images.BaseUrlNormal;
    }

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();

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

    //app.UseDeveloperExceptionPage();

    app.UseCors("AllowAll");

    app.MapOpenApi();

    app.MapScalarApiReference(options =>
    {
        options.WithOpenApiRoutePattern("/openapi/v1.json");

        options.Title = "APM PROTOTYPE API";
    });

    app.UseResponseCompression();

    // app.UseHttpsRedirection();

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