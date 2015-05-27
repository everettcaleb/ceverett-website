using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.WebUtilities;
using Microsoft.AspNet.StaticFiles;
using Microsoft.Framework.DependencyInjection;
using CEverett.Services;

namespace CEverett
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(typeof(IPostProvider), Services.PostProvider.PostProviderFactory.Create);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseErrorPage(ErrorPageOptions.ShowAll);
            app.UseStaticFiles(new StaticFileOptions {
                OnPrepareResponse = (context) => {
                    context.Context.Response.Headers.Add("Cache-Control", new [] { "max-age=86400000" });
                }
            });
            app.UseStatusCodePages();
            app.UseMvc();
            
            app.Run(async (context) => {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("404 Page Not Found");
            });
        }
    }
}
