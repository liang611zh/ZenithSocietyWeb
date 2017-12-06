using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZenithWebSite.Data;
using ZenithWebSite.Models;
using ZenithWebSite.Services;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Globalization;
using Microsoft.Extensions.Options;

namespace ZenithWebSite
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
            services.AddLocalization(opts => { opts.ResourcesPath = "Resource"; });
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddCors();
            services.AddMvc()
                .AddViewLocalization(
                    Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix,
                    opts => { opts.ResourcesPath = "Resources"; })
                    .AddDataAnnotationsLocalization();
            
                
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Zenith Society Core API (LIANG & JIM)", Version = "v1" });
            });
            services.Configure<RequestLocalizationOptions>(opts =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en"),
                    new CultureInfo("en-US"),
                    new CultureInfo("zh-CN")
                };
                opts.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US");

                opts.SupportedCultures = supportedCultures;
                opts.SupportedUICultures = supportedCultures;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext ctx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseCors(builder => 
                builder.WithOrigins("*").AllowAnyHeader()
            );
            app.UseStaticFiles();
            var options =
                app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
           
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZenithSocietyCore V1");
            });

            if (ctx.Database.IsSqlite())
            {
                if (ctx.Database.EnsureCreated())
                {
                    DummyData.Initialize(ctx, app.ApplicationServices);
                }
            }
        }
    }
}
