using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;

namespace MongoMvc
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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(Configuration);

            //configure the options <classname> and bind from the configuration, uses the IOptions interface Microsoft.Framework.OptionsModel
            services.Configure<Settings>(Configuration);

            //add the speaker repository to the service collection
            services.AddSingleton<ISpeakerRespository, SpeakerRepository>();
          
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
            app.UseWelcomePage();

           
        }
    }
}
