﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InGaiaWeather.Model.Spotify.ItensPlayList
{
    public class ItensPlayList
    {
        public string href { get; set; }
        public List<Item> items { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
        public int offset { get; set; }
        public object previous { get; set; }
        public int total { get; set; }
    }
}
