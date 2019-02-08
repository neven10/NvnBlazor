using Microsoft.AspNetCore.Components.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NvnBlazor.App.Interface;
using NvnBlazor.App.Repository;
using NvnBlazor.App.ViewModels;
using System.Net.Http;

namespace NvnBlazor.App
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddScoped<IPlaylist<YoutubeViewModel>, YoutubeRepository>();
            services.AddScoped<IWeather,OpenWeatherRepository>();
            services.AddScoped<IBasicInfo, IPStackAPIRepository>();
            services.AddScoped<IIndexApi, PublicApiRepository >(); 
            services.AddScoped<HttpClient>();
           


        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
