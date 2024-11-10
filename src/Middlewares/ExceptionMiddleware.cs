using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ParcelCalculator.Exceptions;
using System.Net;
using System.Text.Json;

namespace ParcelCalculator.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            {
                try
                {
                    await _next(httpContext);
                }
                catch (Exception ex)
                {
                    await HandleExceptionAsync(httpContext, ex);

                }
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var problemDetailsFactory = context?.RequestServices?
                .GetRequiredService<ProblemDetailsFactory>();

            ProblemDetails problem;
            int statusCode;

            switch (exception)
            {
                case ParameterValidationException parameterValidationException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    context!.Response.StatusCode = statusCode;
                    problem = problemDetailsFactory!.CreateProblemDetails(context, statusCode);
                    problem.Detail = parameterValidationException.Message;
                    break;
                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    context!.Response.StatusCode = statusCode;
                    problem = problemDetailsFactory!.CreateProblemDetails(context, statusCode);
                    problem.Detail = exception.Message;
                    break;
            }

            await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
        }
    }
}
