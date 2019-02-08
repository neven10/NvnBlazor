using Microsoft.AspNetCore.Components;
using NvnBlazor.App.Interface;
using NvnBlazor.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NvnBlazor.App.Components.BasicInfo
{
    public class BasicInfoModel : ComponentBase
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