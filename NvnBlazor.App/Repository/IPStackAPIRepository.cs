using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Http;
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
    public class IPStackAPIRepository : IBasicInfo
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly SettingsRoot settingsRoot;
        private readonly string apiKey;
        private readonly HttpClient httpClient;

        public IPStackAPIRepository(IOptions<SettingsRoot> options, HttpClient client, IHttpContextAccessor accessor)
        {
            httpContextAccessor = accessor;
            httpClient = client;
            settingsRoot = options.Value;
            apiKey = settingsRoot.APIKeys.IPKey;

        }

        public async Task<BasicInfoViewModel> SetInfoAsync()
        {
            var model = new BasicInfoViewModel();
            var response = await RootInfo();
            model.IPstring = response.ip;
            model.IPtype = response.type;
            model.City = response.city ?? "No data";
            model.CountryName = response.country_name;
            model.Capital = response.location.capital;
            model.Zip = response.zip ?? "No data";
            return model;

        }


        private async Task<BasicInfoRootObject> RootInfo()
        {
            //BasicInfoRootObject info = await httpClient.GetJsonAsync<BasicInfoRootObject>("http://api.ipstack.com/77.239.88.101?access_key=" + apiKey + "");
             BasicInfoRootObject info = await httpClient.GetJsonAsync<BasicInfoRootObject>("http://api.ipstack.com/" +GetClientIP()+ "?access_key=" + apiKey + "");            
            return info;
        }

        private string GetClientIP()
        {
            string ip = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            if (ip == "0.0.0.1")
                return "77.239.88.101";
            else
                return ip;
        }
    }
}
