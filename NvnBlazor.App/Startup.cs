using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using NvnBlazor.App.Interface;
using NvnBlazor.App.Models;
using NvnBlazor.App.Repository;
using NvnBlazor.App.Services;
using NvnBlazor.App.ViewModels;

namespace NvnBlazor.App
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ToDoService>();
            services.AddScoped<IPlaylist<YoutubeViewModel>, YoutubeRepository>();
            services.AddScoped<IWeather,OpenWeatherRepository>();

        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
