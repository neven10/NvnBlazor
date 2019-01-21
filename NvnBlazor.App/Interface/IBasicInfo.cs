using NvnBlazor.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NvnBlazor.App.Interface
{
    public interface IBasicInfo
    {
        Task<BasicInfoViewModel> SetInfoAsync();
    }
}
