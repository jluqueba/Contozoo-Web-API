using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contozoo
{
	public static class AppBuilderExtensions
	{
        public static IApplicationBuilder SeedData(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                    .GetRequiredService<IServiceScopeFactory>()
                    .CreateScope();

            var service = serviceScope.ServiceProvider;

            DataSeeder.Seed(service);

            return app;
        }
    }
}
