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
using System.Threading.Tasks;

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Enables default file mapping on the current path
            //UseDefaultFiles middleware must come before UseStaticFiles() middleware 
            //Note* : Default files must be name with default.html or index.html
            //UseDefaultFiles only serves only wwwroot folder files.
            //app.UseDefaultFiles();

            //By default UseDefaultFiles finds and map http request to default.html or index.html
            //we can chanege file name as per our requirement as following.
            //DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("foo.html");
            //app.UseDefaultFiles(defaultFilesOptions);

            //Enables static file serving for the current request path
            app.UseStaticFiles();

            
            //UseFileServer middleware comments the functionality of UseDefaultFiles,UseStaticFiles
            //and UseDirectoryBrowser middlewares. 
            //Lets replace UseDefaultFiles and UseStaticFiles middlewares with UseFileServer
            //By default UseFileServer finds and map http request to default.html or index.html
            //we can chanege file name as per our requirement as following.
            FileServerOptions fileServerOptions = new FileServerOptions();
            fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("fileServerOptions.html");
            app.UseFileServer(fileServerOptions);

            
            //public static void Run(this IApplicationBuilder app, RequestDelegate handler);
            //Parameters:
            //app:The Microsoft.AspNetCore.Builder.IApplicationBuilder instance.
            //handler:A delegate that handles the request.
            //Adds a terminal middleware delegate to the application's request pipeline.
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync(_config["MyKey"]);
            //});

            //public static IApplicationBuilder Use(this IApplicationBuilder app, Func<HttpContext, Func<Task>, Task> middleware);
            //Parameters:
            //app:The Microsoft.AspNetCore.Builder.IApplicationBuilder instance.
            //middleware:A function that handles the request or calls the given next function.
            // Returns: The Microsoft.AspNetCore.Builder.IApplicationBuilder instance.
            //Adds a middleware delegate defined in-line to the application's request pipeline.
            app.Use(async (context, next) =>
            {
                //await context.Response.WriteAsync("I am 1st Middleware in Request Procesing Pipeline.\n");

                logger.LogInformation("MW1 : Incoming Request\n");
                await next();
                logger.LogInformation("MW1 : Outgoing Reesponse\n");
            });
            app.Use(async (context, next) =>
            {
                //await context.Response.WriteAsync("I am 2nd Middleware in Request Procesing Pipeline.\n");
                logger.LogInformation("MW2 : Incoming Request\n");
                await next();
                logger.LogInformation("MW2 : Outgoing Reesponse\n");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("MW3 (Terminal middleware) : Request Handeled And Response Produced.\n");
                logger.LogInformation("MW3 (Terminal middleware) : Request Handeled And Response Produced.\n");
            });

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
