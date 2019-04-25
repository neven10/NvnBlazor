using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NvnBlazor.Interface;
using NvnBlazor.Repository;
using NvnBlazor.ViewModels;
using System.Net.Http;

namespace NvnBlazor
{
    public class Startup
    {
        IConfiguration Configuration;

        public Startup(IWebHostEnvironment env)
        {

            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            var appSettings = Configuration.GetSection("SettingsRoot");
            services.Configure<SettingsRoot>(appSettings);

            services.AddHttpContextAccessor();

            services.AddTransient<IPlaylist<YoutubeViewModel>, YoutubeRepository>();
            services.AddTransient<IWeather,OpenWeatherRepository>();
            services.AddTransient<IBasicInfo, IPStackAPIRepository>();
            services.AddTransient<IIndexApi, PublicApiRepository >(); 
            services.AddScoped<HttpClient>();
           


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
