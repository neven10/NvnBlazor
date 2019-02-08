using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NvnBlazor.App;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;

namespace NvnBlazor.Server
{
    public class Startup
    {
        IConfiguration Configuration;

        public Startup(IHostingEnvironment env)
        {

            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json").Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorComponents<App.Startup>();
        

            var appSettings = Configuration.GetSection("SettingsRoot");
            services.Configure<SettingsRoot>(appSettings);

            services.AddHttpContextAccessor();

        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
         

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
            }            
            app.UseStaticFiles();
            app.UseRazorComponents<App.Startup>();
        }
    }
}
