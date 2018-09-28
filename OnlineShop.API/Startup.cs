using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using IdentityServer4;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using OnlineShop.Models;
using OnlineShop.Architecture.Services;
using OnlineShop.Repositorie;
using OnlineShop.API;
using System.Reflection;
using OnlineShop.Infrastructure;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Microsoft.Extensions.Options;
using System;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace OnlineShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {       


            services.AddDbContext<ShopDbContext>(options =>
                                                 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                                                 b => b.MigrationsAssembly("OnlineShop.Models")));


            var migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            services.AddMvc();        

            services.AddAutoMapper();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IRepository, Repository>();

            services.AddIdentityServer()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                    builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsAssembly(migrationAssembly));
                })
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients());

            services.AddAuthentication()
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "resourceApi";
                });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseCors(policy =>
            //{
            //    policy.AllowAnyHeader();
            //    policy.AllowAnyMethod();
            //    policy.AllowAnyOrigin();
            //});
            app.UseIdentityServer();
            IdentityServerDatabaseInitialization.InitializeDatabase(app);
            //app.UseOpenIdConnectAuthentication(new IdentityServerAuthenticationOptions
            //{
            //    Authority = "http://localhost:5000",
            //    RequireHttpsMetadata = false,
            //    ApiName = "resourceApi"

            //});
            app.UseMvc(); 
        }
    }
}
