using NvnBlazor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NvnBlazor.Interface
{
    public interface IBasicInfo
    {
        Task<BasicInfoViewModel> GetBasicInfoAsync();
        string GetClientIP();
    }
}
