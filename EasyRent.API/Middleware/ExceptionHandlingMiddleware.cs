using EasyRent.Application.Common.Exceptions;
using System.Net;
using System.Text.Json;

namespace EasyRent.API.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception: {Message}", ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";

        var (statusCode, message) = ex switch
        {
            NotFoundException           => (HttpStatusCode.NotFound,           ex.Message),
            BusinessRuleException       => (HttpStatusCode.BadRequest,         ex.Message),
            ForbiddenException          => (HttpStatusCode.Forbidden,          ex.Message), 
            UnauthorizedAccessException => (HttpStatusCode.Unauthorized,       ex.Message),
            _                           => (HttpStatusCode.InternalServerError, "An unexpected error occurred.")
        };

        context.Response.StatusCode = (int)statusCode;

        var body = JsonSerializer.Serialize(new
        {
            status  = (int)statusCode,
            error   = statusCode.ToString(),
            message
        });

        await context.Response.WriteAsync(body);
    }
}