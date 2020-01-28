using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HttpContext
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                context.Items.Add("text", "Привет мир");
                await next.Invoke();
            });

            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                if (context.Items.ContainsKey("text"))
                    await context.Response.WriteAsync($"Текст: {context.Items["text"]}");
                else
                    await context.Response.WriteAsync("Случайный текст");
            });
        }
    }
}
