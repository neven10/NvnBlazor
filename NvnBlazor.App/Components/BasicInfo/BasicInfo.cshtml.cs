using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Http;
using NvnBlazor.App.Interface;
using NvnBlazor.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NvnBlazor.App.Components.BasicInfo
{
    public class BasicInfoModel : BlazorComponent
    {
        [Inject]
        protected IBasicInfo Info { get; set; }

        public BasicInfoViewModel info = new BasicInfoViewModel();

        protected override async Task OnInitAsync()
        {
            info = await Info.GetBasicInfoAsync();
        }
    }
}