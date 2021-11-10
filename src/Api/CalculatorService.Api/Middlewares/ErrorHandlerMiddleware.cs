using CalculatorService.Api.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CalculatorService.Api.Middlewares
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                await CreateHttpError(context, ex);
            }
        }

        private async Task CreateHttpError(HttpContext context, Exception ex)
        {
            var error = HttpErrorFactory.CreateFrom(ex);


            context.Response.Headers["Content-Type"] = new[] { "application/json" };
            context.Response.StatusCode = error.Code;

            await context.Response.WriteAsync(JsonSerializer.Serialize(error));
        }
    }
}
