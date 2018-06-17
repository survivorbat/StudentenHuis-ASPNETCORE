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
            services.AddTransient<IUserRepository, EFUserRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Voor demonstratie heb ik de wachtwoorden simpel gehouden, wanneer de applicatie gedeployed zou worden zouden deze opties uiteraard eruit gehaald worden
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment() || true)
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
                    name: "DefaultWithId",
                    template: "{controller=Home}/{action=Index}/{id:int}"
                );
                routes.MapRoute(
                    name: "Default",
                    template: "{controller=Home}/{action=Index}"
                );
            });
        }
    }
}
