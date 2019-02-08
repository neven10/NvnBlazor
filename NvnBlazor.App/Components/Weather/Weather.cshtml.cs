using Microsoft.AspNetCore.Components;
using NvnBlazor.App.Interface;
using NvnBlazor.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NvnBlazor.App.Components.Weather
{
    public class WeatherModel : ComponentBase
    {
       [Inject]
       protected IWeather Weather { get; set; }

       public WeatherViewModel weather = new WeatherViewModel();



        protected override async Task OnInitAsync()
        {

            weather = await Weather.GetWeatherAsync();

        }
    }
}