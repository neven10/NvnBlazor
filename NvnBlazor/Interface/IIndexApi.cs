using NvnBlazor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NvnBlazor.Interface
{
    public interface IIndexApi
    {
        Task<List<IndexApiViewModel>> GetIndexApiAsync();
        Task<List<IndexApiViewModel>> GetIndexApiAsync(string category);
        Task<List<string>> GetCategories();
    }
}
