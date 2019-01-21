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

        public List<IndexApiViewModel> index = new List<IndexApiViewModel>();
        public List<List<IndexApiViewModel>> splitList = new List<List<IndexApiViewModel>>();

        public void SplitLists()
        {            
            //var sl = new List<List<IndexApiViewModel>>();
            var grouping = index.GroupBy(x => x.Category).ToList();
            foreach (var s in grouping)
            {
                splitList.Add(s.ToList());
            } 
           
        }

}
}