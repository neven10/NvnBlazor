﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NvnBlazor
{
    public class SettingsRoot
    {
        public APIKeys APIKeys { get; set; }
        public Misc Misc { get; set; }
    }

    public class APIKeys
    {
        public string YoutubeKey { get; set; } 
        public string WeatherKey { get; set; } 
        public string IPKey { get; set; }

    }

    public class Misc
    {
        public string YoutubeChannelId { get; set; }
        public string YoutubePlaylistId { get; set; }

    }



}
