using Microsoft.AspNetCore.Blazor.Components;
using NvnBlazor.App.Interface;
using NvnBlazor.App.Services;
using NvnBlazor.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NvnBlazor.App.Components
{
    public class WeatherModel : BlazorComponent
    {
       [Inject]
       protected IWeather Weather { get; set; }

       public WeatherViewModel weather = new WeatherViewModel();


    }
}