using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.Extensions.Options;
using NvnBlazor.App.Interface;
using NvnBlazor.App.DTO;
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
        private readonly HttpClient httpClient;

        public OpenWeatherRepository(IOptions<SettingsRoot> options, HttpClient client)
        {
            settingsRoot = options.Value;
            apiKey = settingsRoot.APIKeys.WeatherKey;
            httpClient = client;
    
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


        private async Task<WeatherRootObject> RootWeather()
        {
            //HttpClient client = new HttpClient();
            WeatherRootObject rootWeatherObject = await httpClient.GetJsonAsync<WeatherRootObject>("http://api.openweathermap.org/data/2.5/weather?q=Bijeljina&units=metric&APPID="+apiKey+"");
            return rootWeatherObject;
        }

        //private async string GetCurrentCity()
        //{
        //    HttpClient client = new HttpClient();
        //    BasicInfoRootObject info = await client.GetJsonAsync<BasicInfoRootObject>("http://api.ipstack.com/77.239.88.101?access_key=" + apiKey + "");
        //    // BasicInfoRootObject info = await client.GetJsonAsync<BasicInfoRootObject>("http://api.ipstack.com/" +GetClientIP()+ "?access_key=" + apiKey + "");
        //    return "s";
        //}
    }
}
