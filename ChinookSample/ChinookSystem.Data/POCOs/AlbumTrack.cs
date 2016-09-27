using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.Data.DTOs
{
    public class AlbumTrack
    {
        public string Name { get; set; }
        public int TotalTracksforAlbum { get; set; }
        public decimal TotalPriceForalbumtracks { get; set; }
        public double AverageTrackLengthA { get; set; }
        public double AverageTrackLengthB { get; set; }
    }
}
