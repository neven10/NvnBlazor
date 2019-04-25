using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using NvnBlazor.DTO;
using NvnBlazor.Interface;
using NvnBlazor.ViewModels;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace NvnBlazor.Repository
{
    public class OpenWeatherRepository : IWeather
    {
        private readonly SettingsRoot settingsRoot;
        private readonly string openWeatherApiKey;
        private readonly HttpClient httpClient;
        private readonly IBasicInfo  _basicInfo;
        private readonly string ipStackApiKey;

       

        public OpenWeatherRepository(IOptions<SettingsRoot> options, HttpClient client, IBasicInfo  basicInfo)
        {
            settingsRoot = options.Value;
            openWeatherApiKey = settingsRoot.APIKeys.WeatherKey;
            httpClient = client;
            _basicInfo = basicInfo;
            ipStackApiKey = settingsRoot.APIKeys.IPKey;


        }

        public async Task<WeatherViewModel> GetWeatherAsync()
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
            string city = await GetCurrentCity();
            var rootWeatherObject = await httpClient.GetJsonAsync<WeatherRootObject>("http://api.openweathermap.org/data/2.5/weather?q=" + city + "+&units=metric&APPID=" + openWeatherApiKey + "");
            return rootWeatherObject;
        }

        private async Task<string> GetCurrentCity()
        {
            string clientIp = _basicInfo.GetClientIP();
            var ipApiKey = settingsRoot.APIKeys.IPKey;
            BasicInfoRootObject info = await httpClient.GetJsonAsync<BasicInfoRootObject>("http://api.ipstack.com/" + clientIp + "?access_key=" + ipStackApiKey + "");
            string city = info.city;
            return (!string.IsNullOrWhiteSpace(city)) ? city : "Belgrade";       
        }


    }
}
