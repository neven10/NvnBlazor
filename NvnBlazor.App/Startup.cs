using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using NvnBlazor.App.Interface;
using NvnBlazor.App.Models;
using NvnBlazor.App.Repository;
using NvnBlazor.App.ViewModels;
using System.Net.Http;

namespace NvnBlazor.App
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddTransient<IPlaylist<YoutubeViewModel>, YoutubeRepository>();
            services.AddTransient<IWeather,OpenWeatherRepository>();
            services.AddTransient<IBasicInfo, BasicInfoRepository>();
            services.AddTransient<HttpClient>();


        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
