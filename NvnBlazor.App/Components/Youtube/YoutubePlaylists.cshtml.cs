using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Components;
using NvnBlazor.App.Interface;
using NvnBlazor.App.ViewModels;

namespace NvnBlazor.App.Components.Youtube
{
    public class YoutubePlaylistsModel : BlazorComponent
    {
      
        [Inject]
        IPlaylist<YoutubeViewModel> Playlist { get; set; }

        public List<YoutubeViewModel> YoutubeViewModelsList = new List<YoutubeViewModel>();


        protected async Task GetYoutubePlaylists()
        {
            YoutubeViewModelsList = await Playlist.GetPlaylists();
        }
    }
}