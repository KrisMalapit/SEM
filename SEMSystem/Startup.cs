
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SEMSystem.Models;

using System.IO;

namespace SEMSystem
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

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddDbContext<SEMSystemContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SEMContextLive")
            , builder => builder.UseRowNumberForPaging() //add this for Incorrect syntax near 'OFFSET'. Invalid usage of the option NEXT in the FETCH statement
            ));

            services.AddCors(opt =>
               opt.AddPolicy("CorsPolicy", policy => {
                   policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://192.168.70.231");
                   policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://sodium2");
                   policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://192.168.30.182");
                   policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://californium:8443/");
               })

           );



            services
               .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options => {
                   options.AccessDeniedPath = "/you-are-not-allowed-page";
                   options.LoginPath = "/Accounts/Login";
               }
            );

            services
               .AddMvc()
               .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env
            //, ILoggerFactory loggerFactory
            )
        {
            var path = Directory.GetCurrentDirectory();
            //loggerFactory.AddFile($"{path}\\Logs\\Log.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                //routes.MapRoute(
                //    name: "accountlogin",
                //    template: "/Accounts/Login",
                //    defaults: new { controller = "Accounts", action = "Login" });

            });
        }
    }
}
