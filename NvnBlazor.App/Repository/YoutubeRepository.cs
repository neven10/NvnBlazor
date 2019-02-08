using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Microsoft.Extensions.Options;
using NvnBlazor.App.Interface;
using NvnBlazor.App.ViewModels;


namespace NvnBlazor.App.Repository
{
    public class YoutubeRepository : IPlaylist<YoutubeViewModel>
    {
        private readonly SettingsRoot settingsRoot;
        private readonly string youtubeApiKey;
        private readonly string channelId;
        private readonly string playlistId;

        public YoutubeRepository(IOptions<SettingsRoot> options)
        {
            settingsRoot = options.Value;
            youtubeApiKey = settingsRoot.APIKeys.YoutubeKey;
            channelId = settingsRoot.Misc.YoutubeChannelId;
            playlistId = settingsRoot.Misc.YoutubePlaylistId;
        }

        public async Task<List<YoutubeViewModel>> GetPlaylistItems()
        {
            List<YoutubeViewModel> playlist = new List<YoutubeViewModel>();
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = settingsRoot.APIKeys.YoutubeKey,
            });
            var details = youtubeService.Channels.List("contentDetails");
            details.Id = channelId;
            var response = await details.ExecuteAsync();            
            var PageToken = "";            
            while (PageToken != null)
            {                
                var PlaylistRequest = youtubeService.PlaylistItems.List("snippet");                
                PlaylistRequest.PlaylistId = playlistId;
                PlaylistRequest.MaxResults = 50;
                PlaylistRequest.PageToken = PageToken;                
                var PlaylistResponse = PlaylistRequest.Execute();                
                foreach (var Video in PlaylistResponse.Items)
                {
                    
                    playlist.Add(new YoutubeViewModel { Title = Video.Snippet.Title, VideoLink = "https://www.youtube.com/embed/" + Video.Snippet.ResourceId.VideoId, ThumbnailLink = Video.Snippet.Thumbnails.Default__.Url });
                }                
                PageToken = PlaylistResponse.NextPageToken;
            }
            return playlist;
        }

        public async Task<List<YoutubeViewModel>> GetPlaylists()
        {
            List<YoutubeViewModel> playlist = new List<YoutubeViewModel>();
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = settingsRoot.APIKeys.YoutubeKey,

            });
            var details = youtubeService.Channels.List("contentDetails");
            details.Id = channelId;
            var response = await details.ExecuteAsync();
            var PlaylistRequest = youtubeService.Playlists.List("snippet");
            PlaylistRequest.ChannelId = channelId;
            PlaylistRequest.PageToken = "";
            PlaylistRequest.MaxResults = 50;
            PlaylistListResponse pr = await PlaylistRequest.ExecuteAsync();

            foreach (var s in pr.Items)
            {
                playlist.Add(new YoutubeViewModel {Title= s.Snippet.Title, VideoLink = "https://www.youtube.com/playlist?list=" + s.Id });
            }
            return playlist;
        }
    }
}
