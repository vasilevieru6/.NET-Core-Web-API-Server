using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.API
{
    public class IdentityServerDatabaseInitialization
    {
        public static void InitializeDatabase(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                PerformMigrations(serviceScope);
                //SeedData(serviceScope);
            }
        }

        private static void SeedData(IServiceScope serviceScope)
        {
            var context = serviceScope
                       .ServiceProvider
                       .GetRequiredService<ConfigurationDbContext>();

            //if (!context.IdentityResources.Any())
            //{
            //    foreach (var resource in Config.GetIdentityResources())
            //    {
            //        context.IdentityResources.Add(resource.ToEntity());
            //    }
            //    context.SaveChanges();
            //}

            if (!context.ApiResources.Any())
            {
                foreach (var resource in Config.GetApiResources())
                {
                    context.ApiResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }
        }

        private static void PerformMigrations(IServiceScope serviceScope)
        {
            serviceScope.ServiceProvider
                    .GetRequiredService<ConfigurationDbContext>()
                    .Database
                    .Migrate();
        }
    }
}
