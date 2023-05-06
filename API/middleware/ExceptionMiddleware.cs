using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.error;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace API.middleware
{
    public class ExceptionMiddleware
    {
        private readonly IHostEnvironment _env;
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(IHostEnvironment host, RequestDelegate next)
        {
            _next = next;
            _env = host;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment()
                    ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
                    : new ApiException((int)HttpStatusCode.InternalServerError);
            
                    var methodName = new StackTrace(ex).GetFrame(1).GetMethod().Name;
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options);
                await context.Response.WriteAsync(json);
            }
        }

    }
}