﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Routing;
using BetCore.Data;
using Microsoft.EntityFrameworkCore;

namespace BetCore
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", reloadOnChange: true, optional: false)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", reloadOnChange: true, optional: true);
            this.Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BetCoreDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddSession(x => x.IdleTimeout = TimeSpan.FromMinutes(5));

            services.AddMvc();
            services.AddMvcCore();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(
                    culture: Configuration["langue"],
                    uiCulture: Configuration["langue"]
                )
            });

           app.Use(async (context, next) =>
           {
               var statusCode = context.Request.Query["statuscode"];
               Debug.WriteLine($"Middelware de test: {statusCode}");
               Debug.WriteLine($"Langue: {Configuration["langue"]}");
               if (!string.IsNullOrWhiteSpace(statusCode))
               {
                   context.Response.StatusCode = 405;
                   await Task.FromResult(0);
               }else
                    await next();
           });

            app.UseStaticFiles();

            app.UseSession();

            app.UseMvc(ConfigureRoute);
            /*app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });*/
        }

        private void ConfigureRoute(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(
                name: "apropos",
                template: "a-propos-de",
                defaults: new { controller = "Home", action = "About" });

            routeBuilder.MapRoute(
                name: "areas",
                template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            routeBuilder.MapRoute(
                name: "Default",
                template: "{controller}/{action}/{id?}");

            

        }
    }
}
