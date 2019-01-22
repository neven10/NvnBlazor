using Microsoft.AspNetCore.Blazor.Components;
using NvnBlazor.App.Interface;
using NvnBlazor.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NvnBlazor.App.Components.PublicAPIs
{
    public class PublicAPIsModel : BlazorComponent
    {
        [Inject]
        public IIndexApi IndexApi { get; set; }

       
      
        protected List<string> categories = new List<string>();
        protected List<IndexApiViewModel> index = new List<IndexApiViewModel>();
        protected List<IndexApiViewModel> category = new List<IndexApiViewModel>();
        protected string CategoryNameLoaded { get; set; }        

        protected bool CategoryToggleDisabled => category != null;

        protected override async Task OnInitAsync()
        {
            categories = await IndexApi.GetCategories();
            index = await IndexApi.GetIndexApiAsync();
           // category = index.Where(x => x.Category == (index.Select(a => a.Category).FirstOrDefault())).ToList();

        }


        protected  void LoadByCategory(string s)
        {
            
            category.Clear();           
            category = index.Where(x => x.Category == s).ToList();
            CategoryNameLoaded = category.Select(x => x.Category).FirstOrDefault();
            StateHasChanged();

        }    
          
    }
}