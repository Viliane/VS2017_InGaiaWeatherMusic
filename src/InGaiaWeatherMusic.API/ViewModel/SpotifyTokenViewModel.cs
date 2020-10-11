using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InGaiaWeatherMusic.API.ViewModel
{
    public class SpotifyTokenViewModel
    {
        public string Access_token { get; set; }
        public string Token_type { get; set; }
        public int Expires_in { get; set; }
    }
}
