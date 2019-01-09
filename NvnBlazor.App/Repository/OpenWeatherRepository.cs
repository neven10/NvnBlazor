using Microsoft.AspNetCore.Blazor;
using Microsoft.Extensions.Options;
using NvnBlazor.App.Interface;
using NvnBlazor.App.Models;
using NvnBlazor.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NvnBlazor.App.Repository
{
    public class OpenWeatherRepository : IWeather
    {
        private readonly SettingsRoot settingsRoot;
        private readonly string apiKey;

        public OpenWeatherRepository(IOptions<SettingsRoot> options)
        {
            settingsRoot = options.Value;
            apiKey = settingsRoot.APIKeys.WeatherKey;
        }

        public async Task<WeatherViewModel> SetWeatherAsync()
        {
            var weather = new WeatherViewModel();
            var response = await RootWeather();
            weather.Location = response.name;
            weather.CurrentWeather = response.weather.Select(x => x.main).FirstOrDefault();
            weather.CurrentTemperature = response.main.temp.ToString();
            weather.MinTemperature = response.main.temp_min.ToString();
            weather.MaxTemperature = response.main.temp_max.ToString();
            return weather;
        }


        private async Task<RootWeatherObject> RootWeather()
        {
            HttpClient client = new HttpClient();
            RootWeatherObject rootWeatherObject = await client.GetJsonAsync<RootWeatherObject>("http://api.openweathermap.org/data/2.5/weather?q=Bijeljina&units=metric&APPID="+apiKey+"");
            return rootWeatherObject;
        }
    }
}
