using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using NvnBlazor.App.Interface;
using NvnBlazor.App.ViewModels;

namespace NvnBlazor.App.Components.Youtube
{
    public class YoutubePlaylistsModel : ComponentBase
    {
      
        [Inject]
        IPlaylist<YoutubeViewModel> Playlist { get; set; }

        public List<YoutubeViewModel> YoutubeViewModelsList = new List<YoutubeViewModel>();

        public bool CheckLoad { get; set; }

        protected override async Task OnInitAsync()
        {
            await GetYoutubePlaylists();
        }

        protected async Task GetYoutubePlaylists()
        {
            YoutubeViewModelsList = await Playlist.GetPlaylists();
        }

        protected void LoadByPlaylist()
        {

        }

    }
}