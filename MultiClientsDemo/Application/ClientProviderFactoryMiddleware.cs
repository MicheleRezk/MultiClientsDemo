using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiClientsDemo.Application
{
    public class ClientProviderFactoryMiddleware
    {
        private readonly RequestDelegate _next;

        public ClientProviderFactoryMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            var clientProviderFactory = httpContext.RequestServices.GetService(typeof(IClientProviderFactory)) as IClientProviderFactory;

            // then set the clientname based on header
            string clientName = httpContext.Request?.Headers["client"].FirstOrDefault();
            clientProviderFactory.ClientName = clientName?? "Client_A";//set default clientname if header don't contains client key

            // Call the next middleware delegate in the pipeline 
            await _next.Invoke(httpContext);
        }
    }
}
