using Microsoft.AspNetCore.Blazor.Components;
using NvnBlazor.App.Interface;
using NvnBlazor.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NvnBlazor.App.Components.Youtube
{
    public class PlaylistItemsModel : BlazorComponent
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

        //RenderFragment CreateDynamicComponent(string a) => builder =>
        //{


        //    // builder.OpenComponent(0, typeof(VideoTemplate ));            
        //    //builder.AddAttribute(1, "YoutubeLink",gg);
        //    //builder.CloseComponent();

        //};

    }
}