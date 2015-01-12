using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;

namespace KWebStartup
{
    public class Startup
    {
        public Startup()
        {
            Configuration = new Configuration()
            .AddJsonFile("config.json")
            .AddEnvironmentVariables();
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigurationServices(IServiceCollection services)
        {
            services.AddMvc(Configuration);

          
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
                      

            // Add MVC to the request pipeline
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });

                routes.MapRoute(
                    name: "api",
                    template: "{controller}/{id?}");
            });
        }
    }
}
