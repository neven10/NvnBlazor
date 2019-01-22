using Microsoft.AspNetCore.Blazor;
using NvnBlazor.App.DTO;
using NvnBlazor.App.Interface;
using NvnBlazor.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NvnBlazor.App.Repository
{
    public class PublicApiRepository : IIndexApi
    {

        private readonly HttpClient httpClient;

        public PublicApiRepository(HttpClient client)
        {
            httpClient = client;
        }
            
        public async Task<List<IndexApiViewModel>> GetIndexApiAsync()
        {
            var list = new List<IndexApiViewModel>();
            var root = await GetRootobject();
            foreach (var s in root.entries)
            {
                list.Add(new IndexApiViewModel { API = s.API,Description = s.Description, Auth = s.Auth, HTTPS=s.HTTPS, Cors=s.Cors, Category=s.Category, Link=s.Link });

            }
            return list;

        }
        public async Task<List<IndexApiViewModel>> GetIndexApiAsync(string category)
        {
            var list = new List<IndexApiViewModel>();
            var root = await GetRootobject(category);
            foreach (var s in root.entries)
            {
                list.Add(new IndexApiViewModel { API = s.API, Description = s.Description, Auth = s.Auth, HTTPS = s.HTTPS, Cors = s.Cors, Category = s.Category, Link = s.Link });

            }
            return list;

        }

        private async Task<IndexApiRootobject> GetRootobject()
        {
            var index = await httpClient.GetJsonAsync<IndexApiRootobject>("https://api.publicapis.org/entries");
            return index;
        }

        private async Task<IndexApiRootobject> GetRootobject(string category)
        {
            var index = await httpClient.GetJsonAsync<IndexApiRootobject>("https://api.publicapis.org/entries?category="+category+"");
            return index;
        }


        public async Task<List<string>> GetCategories() 
        {
            List<string> category = await httpClient.GetJsonAsync<List<string>>("https://api.publicapis.org/categories");
            return category;
        }



    }
}
