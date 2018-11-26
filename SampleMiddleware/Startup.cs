using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace SampleMiddleware
{
    public class Startup
    {
        private object config;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Greeter greeter)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<LoggingMiddleware>();
            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                //var greeting = config["Greetings"];

                Debug.WriteLine("==During Run==");
                //await context.Response.WriteAsync("Hello World!");
                await context.Response.WriteAsync($"Data : {greeter.GetMessageOfTheDay()}");
            });
        }
    }
}
