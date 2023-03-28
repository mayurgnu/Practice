using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EmployeeManagement.CustomMiddleware
{
    public class CustomLoggerMiddleware : IMiddleware
    {
        //Constrructor can be used for following purposes.
        //if we want to use any external services, a logger ,external database, or any other services
        //which has to be dependency injected.

        //Note : 
        //Use ILogger<Startup> _logger not only ILogger _logger;
        //Otherwise
        //When we configure CustomLoggerMiddleware service as AddTransient or AddScoped or AddSingleton in startup.cs
        //then we will have following exception.
        //Error while validating the service descriptor 'ServiceType: EmployeeManagement.CustomMiddleware.CustomLoggerMiddleware
        //Lifetime: Transient,Scoped,Singleton ImplementationType: EmployeeManagement.CustomMiddleware.CustomLoggerMiddleware':
        //Unable to resolve service for type 'Microsoft.Extensions.Logging.ILogger' while attempting to activate
        //'EmployeeManagement.CustomMiddleware.CustomLoggerMiddleware'

        private readonly ILogger<Startup> _logger;
        public CustomLoggerMiddleware(ILogger<Startup> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("CustomLoggerMiddleware : Request\n");
            _logger.LogInformation("CustomLoggerMiddleware : Request\n");
            await next(context);
            await context.Response.WriteAsync("CustomLoggerMiddleware : Response");
            _logger.LogInformation("CustomLoggerMiddleware : Response");

        }
    }
}
