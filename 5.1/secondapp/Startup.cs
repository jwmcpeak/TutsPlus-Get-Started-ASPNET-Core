using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using secondapp.Data;

namespace secondapp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        private readonly IHostingEnvironment _env;

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            //if (_env.IsDevelopment()) {
                services.AddScoped<IGuitarRepository, StaticGuitarRepository>();
            //}
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "guitars-action",
                    template: "products/guitars/{id}/{action}",
                    defaults: new {controller = "guitars"}
                );

                routes.MapRoute(
                    name: "guitars-single",
                    template: "products/guitars/{id}",
                    defaults: new { controller = "guitars", action = "SingleProduct" }
                );

                routes.MapRoute(
                    name: "guitars-index",
                    template: "products/guitars",
                    defaults: new { controller = "guitars", action = "index" }
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // products/guitars/10

            // products/pizza/edit/120
            
            // products/edit/10 -> ProductsController.Edit(10);

            // localhost:5000/controller/action/id
        }
    }
}
