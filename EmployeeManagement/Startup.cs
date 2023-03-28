using EmployeeManagement.CustomMiddleware;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Two steps to setup MVC in ASP.NET Core Application
            services.AddMvc();

            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();

            //To be able to return data in XML format, we have to add Xml Serializer Formatter by calling AddXmlSerializerFormatters() method in ConfigureServices() method in Startup.cs file.
            //services.AddMvc().AddXmlSerializerFormatters();

            services.AddTransient<CustomLoggerMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<CustomLoggerMiddleware>();

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    //endpoints.MapGet("/", async context =>
            //    //{
            //    //    await context.Response.WriteAsync("Hello World!");
            //    //});
            //    endpoints.MapControllerRoute(
            //   name: "default",
            //    //pattern: "{controller=Home}/{action=details}/{id?}");
            //    pattern: "{controller=Home}/{action=details}/{id?}");

            //});
        }
    }
}
