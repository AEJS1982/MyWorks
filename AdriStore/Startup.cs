using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADRISTORE.BE;
using AdriStoreWeb;
using AdriStoreWeb.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp1
{
    public class Startup
    {
        //Test3
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Config.CnxStr = Configuration.GetValue<String>("CnxStr");
            Config.UrlBase= Configuration.GetValue<String>("UrlAppBase");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                
            });

            services.AddDistributedMemoryCache();
            

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddNCacheSession(Configuration.GetSection("NCacheSessions"));
            services.AddSession(opts => opts.Cookie.IsEssential = true);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IHttpContextAccessor accessor)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UsePathBase(Config.UrlBase);
            app.UseStaticFiles();
            app.UseCookiePolicy();

            //app.UseNCacheSession();
            app.UseSession();

            /*app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });*/

            app.UseMvcWithDefaultRoute();

            Helper.accessor = accessor;
            SessionCarrito.accessor= accessor;


        }
    }
}
