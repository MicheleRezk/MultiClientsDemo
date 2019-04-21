using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiClientsDemo.Application
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseClientProviderFactoryMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ClientProviderFactoryMiddleware>();
        }
    }
}
