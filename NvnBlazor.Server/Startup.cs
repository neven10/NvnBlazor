using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Blazor.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NvnBlazor.App;
using NvnBlazor.App.Models;
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
            using (var db = new DbNevenBlazorContext())
            {
                db.Database.EnsureCreated();
            }


            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Adds the Server-Side Blazor services, and those registered by the app project's startup.

            services.AddEntityFrameworkSqlite().AddDbContext<DbNevenBlazorContext>();
            services.AddServerSideBlazor<App.Startup>();

            var appSettings = Configuration.GetSection("SettingsRoot");
            services.Configure<SettingsRoot>(appSettings);

            services.AddResponseCompression(options =>
            {
                

                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                {
                    MediaTypeNames.Application.Octet,
                    WasmMediaTypeNames.Application.Wasm,
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            // Use component registrations and static files from the app project.
            app.UseServerSideBlazor<App.Startup>();
        }
    }
}
