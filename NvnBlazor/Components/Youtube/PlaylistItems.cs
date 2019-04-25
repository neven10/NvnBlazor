using Microsoft.AspNetCore.Components;
using NvnBlazor.Interface;
using NvnBlazor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NvnBlazor.Components.Youtube
{
    public class PlaylistItemsModel : ComponentBase
    {
        [Inject]
        IPlaylist<YoutubeViewModel> PlaylistItems { get; set; }

        public List<YoutubeViewModel> YoutubeViewModelsList = new List<YoutubeViewModel>();


        protected async Task GetYoutubeVideoDetails()
        {
            YoutubeViewModelsList = await PlaylistItems.GetPlaylistItems();
        }

        protected override async Task OnInitAsync()
        {
            await GetYoutubeVideoDetails();
        }


    }
}