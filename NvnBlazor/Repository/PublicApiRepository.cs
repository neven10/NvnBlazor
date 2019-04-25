using Microsoft.AspNetCore.Components;
using NvnBlazor.DTO;
using NvnBlazor.Interface;
using NvnBlazor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NvnBlazor.Repository
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
            IndexApiRootobject index = await httpClient.GetJsonAsync<IndexApiRootobject>("https://api.publicapis.org/entries");
            return index;
        }

        private async Task<IndexApiRootobject> GetRootobject(string category)
        {
            IndexApiRootobject index = await httpClient.GetJsonAsync<IndexApiRootobject>("https://api.publicapis.org/entries?category=" + category + "");
            return index;
        }


        public async Task<List<string>> GetCategories() 
        {
            List<string> category = await httpClient.GetJsonAsync<List<string>>("https://api.publicapis.org/categories");
            return category;
        }



    }
}
