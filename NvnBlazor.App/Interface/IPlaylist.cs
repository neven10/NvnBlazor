using NvnBlazor.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NvnBlazor.App.Interface
{
    public interface IPlaylist<T> where T : class
    {
         Task<List<T>> GetPlaylistItems();
         Task<List<T>> GetPlaylists();
    }
}
