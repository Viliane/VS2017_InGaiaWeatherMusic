using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InGaiaWeather.Model.Spotify.ItensPlayList
{
    public class Item
    {
        public DateTime added_at { get; set; }
        public AddedBy added_by { get; set; }
        public bool is_local { get; set; }
        public object primary_color { get; set; }
        public Track track { get; set; }
        public VideoThumbnail video_thumbnail { get; set; }
    }
}
