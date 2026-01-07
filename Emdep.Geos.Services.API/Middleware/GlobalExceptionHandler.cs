using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace Emdep.Geos.API.Middleware;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var problemDetails = new ProblemDetails
        {
            Instance = httpContext.Request.Path
        };

        switch (exception)
        {
            case MySqlException sqlEx:
                HandleSqlException(sqlEx, problemDetails);
                logger.LogWarning(sqlEx, "Database Error: {Message}", sqlEx.Message);
                break;

            case OperationCanceledException:
                problemDetails.Status = 499;
                problemDetails.Title = "Request Cancelled";
                problemDetails.Detail = "The request was cancelled by the client.";
                logger.LogInformation("Request cancelled by the client.");
                break;

            case TimeoutException:
                problemDetails.Status = StatusCodes.Status504GatewayTimeout;
                problemDetails.Title = "Timeout";
                problemDetails.Detail = "The operation took too long to respond.";
                logger.LogError(exception, "Operation timeout.");
                break;

            default:
                problemDetails.Status = StatusCodes.Status500InternalServerError;
                problemDetails.Title = "Internal Server Error";
                problemDetails.Detail = "An unexpected error occurred while processing the request.";
                logger.LogError(exception, "Unhandled exception: {Message}", exception.Message);
                break;
        }

        httpContext.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

    private static void HandleSqlException(MySqlException ex, ProblemDetails problemDetails)
    {
        switch (ex.Number)
        {
            case 1062: // Duplicate entry
                problemDetails.Status = StatusCodes.Status409Conflict;
                problemDetails.Title = "Data Conflict";
                problemDetails.Detail = "The record you are trying to create already exists.";
                break;

            case 1451: // Cannot delete or update a parent row (FK constraint fails)
            case 1452: // Cannot add or update a child row (FK constraint fails)
                problemDetails.Status = StatusCodes.Status409Conflict; // Or 400
                problemDetails.Title = "Integrity Violation";
                problemDetails.Detail = "The operation cannot be completed due to data dependencies.";
                break;

            default:
                // Other SQL errors remain as 500
                problemDetails.Status = StatusCodes.Status500InternalServerError;
                problemDetails.Title = "Database Error";
                problemDetails.Detail = "Error communicating with the database.";
                break;
        }
    }
}