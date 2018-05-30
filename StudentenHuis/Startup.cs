using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentenHuis.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using StudentenHuis.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using StudentenHuis.Models.ViewModels;

namespace StudentenHuis
{
    public class Startup
    {
        IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json").Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
            Configuration["Data:StudentenhuisMaaltijden:ConnectionString"]));
            services.AddTransient<IMealRepository, EFMealRepository>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "Meal/{id}",
                    defaults: new { controller = "Meal", action = "Detail" }
                );
                routes.MapRoute(
                    name: null,
                    template: "Meal",
                    defaults: new { controller = "Meal", action = "Index" }
                );
                routes.MapRoute(
                    name: null,
                    template: "Account/Login",
                    defaults: new { controller = "Account", action = "Login" }
                );
                routes.MapRoute(
                    name: null,
                    template: "Account/Logout",
                    defaults: new { controller = "Account", action = "Logout" }
                );
                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { controller = "Home", action = "Index" }
                );
                routes.MapRoute(
                    name: null,
                    template: "Home",
                    defaults: new { controller = "Home", action = "Index" }
                );
            });
        }
    }
}
