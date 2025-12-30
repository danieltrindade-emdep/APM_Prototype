using Asp.Versioning;
using Emdep.Geos.Core.Interfaces;
using Emdep.Geos.Infrastructure.Repositories;
using Microsoft.AspNetCore.ResponseCompression;
using MySqlConnector;
using Scalar.AspNetCore;
using System.IO.Compression;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

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

builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(builder.Configuration.GetConnectionString("WorkbenchContext")));

builder.Services.AddScoped<IAPMRepository, APMRepository>();

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

app.UseDeveloperExceptionPage();

app.UseCors("PermitirTudo");

// Mapeia o documento JSON em /openapi/v1.json
app.MapOpenApi();

app.MapScalarApiReference(options =>
{
    options.WithOpenApiRoutePattern("/openapi/v1.json");

    options.Title = "Minha API";
});

app.UseResponseCompression();

// 4. COMENTE ESTA LINHA SE ESTIVER A USAR HTTP (Sem certificado SSL) NO IP
// Se aceder via http://92... e isto estiver ativo, a API tenta forçar https://
// e o pedido do JSON falha silenciosamente.
// app.UseHttpsRedirection(); // <--- COMENTE ISTO PARA TESTAR

app.UseAuthorization();
app.MapControllers();

app.Run();