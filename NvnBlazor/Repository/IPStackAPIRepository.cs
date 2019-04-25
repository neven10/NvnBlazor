using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using NvnBlazor.DTO;
using NvnBlazor.Interface;
using NvnBlazor.ViewModels;
using System.Net.Http;
using System.Threading.Tasks;



namespace NvnBlazor.Repository
{
    public class IPStackAPIRepository : IBasicInfo
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly SettingsRoot settingsRoot;
        private readonly string ipStackApiKey;
        private readonly HttpClient httpClient;

        public IPStackAPIRepository(IOptions<SettingsRoot> options, HttpClient client, IHttpContextAccessor accessor)
        {
            httpContextAccessor = accessor;
            httpClient = client;
            settingsRoot = options.Value;
            ipStackApiKey = settingsRoot.APIKeys.IPKey;
        }

        public async Task<BasicInfoViewModel> GetBasicInfoAsync()
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
            var clientIp = GetClientIP();
            BasicInfoRootObject info = await httpClient.GetJsonAsync<BasicInfoRootObject>("http://api.ipstack.com/" +clientIp+ "?access_key=" + ipStackApiKey + "");            
            return info;
        }

        public string GetClientIP()
        {
            string ip =  httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();                        
            return (ip == "0.0.0.1") ? "77.239.88.101" : ip;
        }
    }
}
