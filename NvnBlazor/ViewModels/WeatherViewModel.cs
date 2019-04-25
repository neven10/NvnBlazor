using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NvnBlazor.ViewModels
{
    public class WeatherViewModel
    {
        public string Location { get; set; }
        public string CurrentWeather { get; set; }
        public string CurrentTemperature { get; set; }
        public string MinTemperature { get; set; }
        public string MaxTemperature { get; set; }
    }
}
